using Core.Common;
using Core.Dtos;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Quize_App.Services;

namespace Quize_App.Controllers;

[ApiController]
[Route("api/[Controller]/[Action]")]
public class QuoteController : ControllerBase
{
    private readonly QuoteService _quoteService;

    public QuoteController(QuoteService quoteService)
    {
        _quoteService = quoteService;
    }

    [HttpGet(Name = "GetQuoteById")]
    public async Task<ExecutionResult<Quote>> GetQuoteById(int quoteId)
    {
        return await _quoteService.GetQuoteById(quoteId);
    }

    [HttpGet(Name = "GetRandomQuote")]
    public async Task<ExecutionResult<Quote>> GetRandomQuote()
    {
        return await _quoteService.GetRandomQuote();
    }

    [HttpGet(Name = "GetRandomQuoteChoice")]
    public async Task<ExecutionResult<ChoiceQuote>> GetRandomQuoteChoice()
    {
        return await _quoteService.GetRandomQuoteChoice();
    }

    [HttpGet(Name = "GetQuotes")]
    public async Task<ExecutionResult<List<Quote>>> GetQuotes()
    {
        return await _quoteService.GetAllQuotes();
    }

    [HttpPost(Name = "CreateQuote")]
    public async Task<ExecutionResult> AddQuote(QuoteAddDto quote)
    {
        return await _quoteService.CreateQuote(quote);
    }

    [HttpPut(Name = "UpdateQuote")]
    public async Task<ExecutionResult<Quote>> UpdateQuote(Quote quote)
    {
        return await _quoteService.UpdateQuote(quote);
    }

    [HttpPut(Name = "DeleteQuote")]
    public async Task<ExecutionResult> DeleteQuote(int quoteId)
    {
        return await _quoteService.DeleteQuote(quoteId);
    }

}


