using System;
using Core.Common;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;

namespace Quize_App.Services
{

    public class QuoteService
    {

        private readonly IQuoteRepository _repository;

        public QuoteService(IQuoteRepository repository)
        {
            _repository = repository;
        }

        public async Task<ExecutionResult<Quote>> GetQuoteById(int quoteId)
        {
            return await _repository.GetRandomQuoteById(quoteId);
        }

        public async Task<ExecutionResult<Quote>> GetRandomQuote()
        {
            return await _repository.GetRandomQuote();
        }

        public async Task<ExecutionResult<ChoiceQuote>> GetRandomQuoteChoice()
        {
            return await _repository.GetRandomQuoteChoice();
        }

        public async Task<ExecutionResult<List<Quote>>> GetAllQuotes()
        {
            return await _repository.GetQuotes();
        }

        public async Task<ExecutionResult> CreateQuote(QuoteAddDto quote)
        {
            if (string.IsNullOrEmpty(quote.Author) || string.IsNullOrEmpty(quote.QuoteName))
            {
                return new ExecutionResult<bool>
                {
                    Data = false,
                    Message = "Cannot Add, Fields are required",
                    ErrorMessage = "bad Request",
                    StatusCode = 400
                };
            }
            return await _repository.CreateQuote(quote);
        }

        public async Task<ExecutionResult> DeleteQuote(int quoteId)
        {
            return await _repository.DeleteQuote(quoteId);
        }

        public async Task<ExecutionResult<Quote>> UpdateQuote(Quote quote)
        {
            return await _repository.UpdateQuote(quote);
        }

    }
}

