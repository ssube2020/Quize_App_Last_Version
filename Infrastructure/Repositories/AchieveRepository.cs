using System;
using Core.Common;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class AchieveRepository : IAchieveRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AchieveRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ExecutionResult> AchieveUserAnswer(AchieveAnswerDto model)
        {
            try
            {
                UserAchievement entity = new();
                entity.User = model.User;
                entity.Quote = model.Quote;
                entity.QuouteId = model.QuouteId;
                entity.Answer = model.Answer;
                entity.QuoteAuthor = model.QuoteAuthor;

                await _dbContext.UserAchievements.AddAsync(entity);
                await _dbContext.SaveChangesAsync();

                return new ExecutionResult
                {
                    Success = true,
                    Message = "Achieve Added Succesfully"
                };
            }
            catch (Exception ex)
            {
                return new ExecutionResult
                {
                    Success = false,
                    Message = "Achieve Could Not Be Added",
                    ErrorMessage = ex.Message,
                    StatusCode = 500
                };
            }
        }

        public async Task<ExecutionResult<List<UserAchievement>>> GetAchieve()
        {
            try
            {
                List<UserAchievement> quotes = await _dbContext.UserAchievements.ToListAsync();

                return new ExecutionResult<List<UserAchievement>>
                {
                    Success = true,
                    Data = quotes,
                    Count = quotes.Count
                };
            }
            catch (Exception ex)
            {
                return new ExecutionResult<List<UserAchievement>>
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = ex.Message,
                    StatusCode = 500
                };
            }
        }

    }
}

