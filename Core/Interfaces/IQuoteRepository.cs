using System;
using Core.Common;
using Core.Dtos;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IQuoteRepository
    {
        Task<ExecutionResult> CreateQuote(QuoteAddDto quote);
        Task<ExecutionResult<List<Quote>>> GetQuotes();
        Task<ExecutionResult<Quote>> GetRandomQuoteById(int quoteId);
        Task<ExecutionResult<Quote>> GetRandomQuote();
        Task<ExecutionResult<ChoiceQuote>> GetRandomQuoteChoice();
        Task<ExecutionResult> DeleteQuote(int quoteId);
        Task<ExecutionResult<Quote>> UpdateQuote(Quote quote);
    }
}

