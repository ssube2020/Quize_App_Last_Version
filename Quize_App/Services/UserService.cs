using System;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Quize_App.Contracts;
using Quize_App.Exceptions;
using Quize_App.Models.Users;
using Shared;

namespace Quize_App.Services
{
    public class UserService : IUserService
    {
        #region Constructor

        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        #endregion

        public async Task<bool> Delete(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
                throw new NotFoundException(ErrMessages.NotFound);

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
                return true;

            throw new Exception($"{result.Errors.FirstOrDefault().Description}");
        }

        public async Task<List<UserResponse>> GetList()
        {
            var users = await _userManager.Users.ToListAsync();

            return _mapper.Map<List<UserResponse>>(users);
        }

        public async Task<UserResponse> GetById(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
                throw new NotFoundException(ErrMessages.NotFound);

            return _mapper.Map<UserResponse>(user);

        }

        public async Task<UserResponse> Update(UserUpdateRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user == null)
                throw new NotFoundException(ErrMessages.NotFound);

            user.UserName = request.Username;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
                return _mapper.Map<UserResponse>(user);

            throw new Exception($"{result.Errors.FirstOrDefault().Description}");
        }
    }

    //define mapping configuration to IdentityUser to UserResponse
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<IdentityUser, UserResponse>();
        }
    }

}

