using System;
using Infrastructure.DataContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Quize_App.Contracts;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Quize_App.Models;
using Shared.Constants;
using Quize_App.Models.Auth;
using Quize_App.Exceptions;
using Shared;

namespace Quize_App.Services
{
    public class AuthService : IAuthService
    {
        #region Constructor

        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        public AuthService(
            IConfiguration configuration,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context
            )
        {
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }
        #endregion

        #region Methods
        public async Task<AuthResponse> Register(RegistrationRequest request)
        {
            //check if user already exists.
            var existingUser = await _userManager.FindByNameAsync(request.Username);
            if (existingUser != null)
                throw new Exception($"Username '{request.Username}' already exists.");

            var roleName = await GetRoleName("42567b4b-33et-384r-5778-cg215d990e3c");

            var user = new IdentityUser
            {
                UserName = request.Username
            };


            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
            {
                //Assign role to the user.
                await _userManager.AddToRoleAsync(user, roleName);

                var currentUser = await _userManager.FindByNameAsync(user.UserName);

                return new AuthResponse()
                {
                    Id = currentUser.Id,
                    UserName = currentUser.UserName
                };
            }

            throw new Exception($"{result.Errors.FirstOrDefault().Description}");
        }

        public async Task<AuthResult> Login(AuthRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)
                throw new NotFoundException($"Username with this '{request.Username}' not found.");

            var result = await _userManager.CheckPasswordAsync(user, request.Password);
            if (!result)
                throw new BadRequestException(ErrMessages.InvalidPassword);

            return new AuthResult()
            {
                IsSuccess = true,
                AccessToken = await GenerateAccessToken(user),
                SuccessMessage = "logged-in successfully"
            };
        }


        #endregion

        #region PrivateMethods

        /// <summary>
        /// Private method, that checks if role exists or not in Db and return role name.<br/>
        /// If it doesn't exist, default role name is <b>"BasicUser"</b>.
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task<string> GetRoleName(string? roleId)
        {
            string roleName;

            if (roleId != null)
            {
                var role = await _roleManager.FindByIdAsync(roleId);

                if (role == null)
                    throw new Exception("Invalid Role Id");

                roleName = role.Name;
            }
            else roleName = RoleConsts.BasicUser;

            return roleName;
        }

        /// <summary>
        /// Generates new token
        /// </summary>
        /// <param name="user"></param>
        /// <returns>token as string</returns>
        private async Task<string> GenerateAccessToken(IdentityUser user)
        {

            var role = await _userManager.GetRolesAsync(user);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

            var userClaims = await _userManager.GetClaimsAsync(user);

            var claims = new List<Claim>(userClaims)
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim("Id", user.Id),
                new Claim("Role", role.FirstOrDefault())
            };

            var token = new JwtSecurityToken(
                       issuer: _configuration.GetValue<string>("AuthSettings:Issuer"),
                       audience: _configuration.GetValue<string>("AuthSettings:Audience"),
                       expires: DateTime.UtcNow.AddMinutes(15),
                       claims: claims,
                       signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion
    }
}

