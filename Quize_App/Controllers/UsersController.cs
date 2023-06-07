using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Quize_App.Contracts;
using Quize_App.Models.Users;

namespace Quize_App.Controllers
{
    //[Authorize(Roles = "admin")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region controller

        private readonly IUserService _service;
        public UsersController(IUserService servicec) => _service = servicec;
        #endregion

        [HttpGet]
        public async Task<IActionResult> UsersList()
        {
            var result = await _service.GetList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserByID(string id)
        {
            var result = await _service.GetById(id);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _service.Delete(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserUpdateRequest request)
        {
            var result = await _service.Update(request);
            return Ok(result);
        }

    }
}

