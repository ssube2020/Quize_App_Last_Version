using System;
namespace Core.Entities
{
	public class UserAchievement
	{
        public int Id { get; set; }
        public string User { get; set; }
        public int QuouteId { get; set; }
        public string Quote { get; set; }
        public string QuoteAuthor { get; set; }
        public string Answer { get; set; }
    }
}

