using System;
using Core.Common;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;

namespace Quize_App.Services
{
	public class AchieveService
	{
        private readonly IAchieveRepository _repository;

        public AchieveService(IAchieveRepository repository)
        {
            _repository = repository;
        }

        public async Task<ExecutionResult<List<UserAchievement>>> GetAchieve()
        {
            return await _repository.GetAchieve();
        }

        public async Task<ExecutionResult> AchieveUserAnswer(AchieveAnswerDto model)
        {
            return await _repository.AchieveUserAnswer(model);
        }

    }

    
}

