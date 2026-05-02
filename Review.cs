using System;
using System.Collections.Generic;
using System.Text;

namespace misto
{
    internal class Review
    {
        private string _comment = string.Empty;
        private int _rating;
        public Guid ReviewId { get; init; } = Guid.NewGuid();
        public Guid EventId { get; init; } 
        public Guid UserId { get; init; } 
        public string Comment
        {
            get => _comment;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Коментар не може бути порожнім.");
                _comment = value;
            }
        }
        public int Rating
        {
            get => _rating;
            set
            {
                if (value < 1 || value > 5)
                    throw new ArgumentException ("Рейтинг повинен бути від 1 до 5.");
                _rating = value;
            }
        }
        public Review(Guid userId, Guid eventId, string comment, int rating)
        {
            UserId = userId;
            EventId = eventId;
            Comment = comment; 
            Rating = rating;   
        }

    }
}
