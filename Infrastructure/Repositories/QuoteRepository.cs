using System;
using Infrastructure.DataContext;
using System.Globalization;
using Core.Interfaces;
using Core.Common;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Core.Dtos;

namespace Infrastructure.Repositories
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public QuoteRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ExecutionResult> CreateQuote(QuoteAddDto quote)
        {
            try
            {
                Quote entity = new();
                entity.QuoteName = quote.QuoteName;
                entity.Author = quote.Author;

                await _dbContext.Quotes.AddAsync(entity);
                await _dbContext.SaveChangesAsync();

                return new ExecutionResult
                {
                    Success = true,
                    Message = "Quote Added Succesfully"
                };
            }
            catch(Exception ex)
            {
                return new ExecutionResult
                {
                    Success = false,
                    Message = "Quote Could Not Be Added",
                    ErrorMessage = ex.Message,
                    StatusCode = 500
                };
            }
        }

        public async Task<ExecutionResult> DeleteQuote(int quoteId)
        {
            try
            {
                var quote = await _dbContext.Quotes.SingleOrDefaultAsync(x => x.Id == quoteId);
                if(quote != null)
                {
                    _dbContext.Quotes.Remove(quote);
                    await _dbContext.SaveChangesAsync();

                    return new ExecutionResult
                    {
                        Success = true,
                        Message = "Quote Deleted Succesfully"
                    };
                } else
                {
                    return new ExecutionResult
                    {
                        Success = false,
                        Message = "Quote Was Not Delete",
                        ErrorMessage = "Quote Not Found",
                    };
                }
            }
            catch (Exception ex)
            {
                return new ExecutionResult
                {
                    Success = false,
                    Message = "Quote Was Not Deleted Succesfully",
                    ErrorMessage = ex.Message,
                    StatusCode = 500
                };
            }
        }

        public async Task<ExecutionResult<List<Quote>>> GetQuotes()
        {
            try
            {
                List<Quote> quotes = await _dbContext.Quotes.ToListAsync();

                return new ExecutionResult<List<Quote>>
                {
                    Success = true,
                    Data = quotes,
                    Count = quotes.Count
                };
            }
            catch(Exception ex)
            {
                return new ExecutionResult<List<Quote>>
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = ex.Message,
                    StatusCode = 500
                };
            }
            
        }

        public async Task<ExecutionResult<Quote>> GetRandomQuote()
        {
            var randomQuote = _dbContext.Quotes
                            .OrderBy(x => Guid.NewGuid())
                            .FirstOrDefault();

            if (randomQuote != null)
            {
                var secondRandomQuote = _dbContext.Quotes
                            .OrderBy(x => Guid.NewGuid())
                            .FirstOrDefault();

                string[] authors = new string[2];
                authors[0] = randomQuote.Author;
                authors[1] = secondRandomQuote.Author;

                Random random = new Random();
                int randIndex = random.Next(0, authors.Length);

                randomQuote.Author = authors[randIndex];

                return new ExecutionResult<Quote>
                {
                    Success = true,
                    Data = randomQuote
                };
            }
            else
            {
                return new ExecutionResult<Quote>
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = "records not found in db",
                    StatusCode = 404
                };
            }
            
        }

        public async Task<ExecutionResult<ChoiceQuote>> GetRandomQuoteChoice()
        {
            var randomQuote = _dbContext.Quotes
                            .OrderBy(x => Guid.NewGuid())
                            .FirstOrDefault();

            if (randomQuote != null)
            {
                var allQuoteAuthors = await _dbContext.Quotes.Select(x => x.Author).ToListAsync();

                List<string> randomAuthors = new();

                // Shuffle the list of allQuoteAuthors
                Random random = new();
                List<string> shuffledAuthors = allQuoteAuthors.OrderBy(x => random.Next()).ToList();

                // Get the first three authors from the shuffled list
                randomAuthors = shuffledAuthors.Take(3).ToList();
                randomAuthors = randomAuthors.Distinct().ToList();
                if(randomAuthors.Count() != 3)
                {
                    while (true)
                    {
                        var randomQuoteAuthorToAdd = _dbContext.Quotes
                        .OrderBy(x => Guid.NewGuid())
                        .FirstOrDefault();

                        if (!randomAuthors.Contains(randomQuoteAuthorToAdd.Author))
                        {
                            randomAuthors.Add(randomQuoteAuthorToAdd.Author);
                            break;
                        }
                        else { continue; }
                    }
                }

                if (!randomAuthors.Contains(randomQuote.Author))
                {
                    int randomIndex = random.Next(0, 2);
                    randomAuthors[randomIndex] = randomQuote.Author;

                    randomAuthors = randomAuthors.Distinct().ToList();
                    if (randomAuthors.Count != 3)
                    {
                        while (true)
                        {
                            var randomQuoteAuthorToAdd = _dbContext.Quotes
                            .OrderBy(x => Guid.NewGuid())
                            .FirstOrDefault();

                            if (!randomAuthors.Contains(randomQuoteAuthorToAdd.Author))
                            {
                                randomAuthors.Add(randomQuoteAuthorToAdd.Author);
                                break;
                            } else { continue;  }
                        }
                    }
                }

                ChoiceQuote choiceQuote = new();
                choiceQuote.Id = randomQuote.Id;
                choiceQuote.QuoteName = randomQuote.QuoteName;
                choiceQuote.PossibleAuthors = randomAuthors;

                return new ExecutionResult<ChoiceQuote>
                {
                    Success = true,
                    Data = choiceQuote
                };
            }
            else
            {
                return new ExecutionResult<ChoiceQuote>
                {
                    Success = false,
                    Data = null,
                    ErrorMessage = "records not found in db",
                    StatusCode = 404
                };
            }
        }

        public async Task<ExecutionResult<Quote>> GetRandomQuoteById(int quoteId)
        {
            try
            {
                var quote = await _dbContext.Quotes.SingleOrDefaultAsync(k => k.Id == quoteId);
                if(quote != null)
                {
                    return new ExecutionResult<Quote>
                    {
                        Success = true,
                        Data = quote,
                        Message = "success"
                    };
                } else
                {
                    return new ExecutionResult<Quote>
                    {
                        Success = false,
                        Data = quote,
                        Message = "Failure",
                        ErrorMessage = "with this id Quote not found"
                    };
                }
            }
            catch(Exception ex)
            {
                return new ExecutionResult<Quote>
                {
                    Success = false,
                    Message = "Failure",
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<ExecutionResult<Quote>> UpdateQuote(Quote quote)
        {
            try
            {
                var singleQuote = await _dbContext.Quotes.SingleOrDefaultAsync(x => x.Id == quote.Id);
                if (singleQuote != null)
                {
                    singleQuote.Author = quote.Author;
                    singleQuote.QuoteName = quote.QuoteName;

                    _dbContext.Update(singleQuote);
                    await _dbContext.SaveChangesAsync();

                    return new ExecutionResult<Quote>
                    {
                        Success = true,
                        Data = quote,
                        Message = "Quote Updated Succesfully"
                    };
                } else
                {
                    return new ExecutionResult<Quote>
                    {
                        Success = false,
                        Data = quote,
                        Message = "Quote Was Not Updated Succesfully",
                        ErrorMessage = "Not Found Quote With Such Id"
                    };
                }
                
            }
            catch (Exception ex)
            {
                return new ExecutionResult<Quote>
                {
                    Success = false,
                    Message = "Quote Was Not Updated Succesfully",
                    ErrorMessage = ex.Message,
                    Data = quote
                };
            }
        }

    }
}

