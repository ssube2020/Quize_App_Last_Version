using System;
using Core.Common;
using Core.Dtos;
using Core.Entities;

namespace Core.Interfaces
{

    public interface IAchieveRepository
    {
        Task<ExecutionResult> AchieveUserAnswer(AchieveAnswerDto model);
        Task<ExecutionResult<List<UserAchievement>>> GetAchieve();
    }
}

