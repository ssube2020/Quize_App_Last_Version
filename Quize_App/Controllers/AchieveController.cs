using System;
using Core.Common;
using Core.Dtos;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Quize_App.Services;

namespace Quize_App.Controllers
{
    [ApiController]
    [Route("api/[Controller]/[Action]")]
    public class AchieveController : ControllerBase
    {
        private readonly AchieveService _achieveService;
        public AchieveController(AchieveService achieveService)
		{
            _achieveService = achieveService;
		}

        [HttpGet(Name = "GetUserAchievements")]
        public async Task<ExecutionResult<List<UserAchievement>>> GetAchieve()
        {
            return await _achieveService.GetAchieve();
        }

        [HttpPost(Name = "AddAchievement")]
        public async Task<ExecutionResult> AddUserAchievement(AchieveAnswerDto model)
        {
            return await _achieveService.AchieveUserAnswer(model);
        }

    }
}

