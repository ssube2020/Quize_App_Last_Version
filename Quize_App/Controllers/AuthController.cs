using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quize_App.Contracts;
using Quize_App.Models;
using System.Data;

namespace Quize_App.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService authService)
        {
            _service = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthRequest request)
        {
            var result = await _service.Login(request);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequest request)
        {
            var result = await _service.Register(request);

            return Ok(result);
        }
    }
}

