using System;
namespace Core.Dtos
{
	public class ChoiceQuote
	{
        public int Id { get; set; }
        public string QuoteName { get; set; }
        public List<string> PossibleAuthors { get; set; }
    }
}

