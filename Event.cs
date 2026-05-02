using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace misto
{
    public class Event
    {
        private readonly Guid _id = Guid.NewGuid();
        public Guid Id => _id;
        public Guid OwnerId { get; init;}
       


        private string _title = string.Empty;
        public string Title => _title;
        public void ChangeTitle(string newTitle)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
                throw new ArgumentException("Назва не може бути порожньою.");
            if (newTitle.Trim().Length > 100)
                throw new ArgumentException("Назва не більше 100 символів.");

            _title = newTitle.Trim();
        }


        private string _description = string.Empty;
        public string Description => _description;
        public void ChangeDescription(string newDescription)
        {
            if (string.IsNullOrWhiteSpace(newDescription))
                throw new ArgumentException("Опис не може бути порожнім.");
            if (newDescription.Trim().Length > 1000)
                throw new ArgumentException("Опис занадто довгий.");

            _description = newDescription.Trim();

        }


        private decimal _price;
        public decimal Price => _price;
        public void ChangePrice(decimal newPrice)
        {
            if (newPrice < 0)
                throw new ArgumentException("Ціна не може бути відʼємною.");

            _price = newPrice;
        }



        private DateTime _date = DateTime.Now;
        public DateTime Date => _date;
        public void ChangeDate(DateTime newDateTime)
        {
            if (newDateTime < DateTime.Now)
                throw new ArgumentException("Дата не може бути в минулому.");

            _date = newDateTime;
        }

   
        private int _rating;
        public int Rating => _rating;
        public void ChangeRating(int newRating)
        {
            if (newRating < 1 || newRating > 5)
                throw new ArgumentException("Рейтинг 1–5.");

            _rating = newRating;
        }


        private bool _isDeleted;
        public bool IsDeleted => _isDeleted;

        public void Delete()
        {
            if (_isDeleted)
                throw new InvalidOperationException("Вже видалено.");

            _isDeleted = true;
        }

        public Event(string title, DateTime date, Guid ownerId)
        {
            OwnerId = ownerId;

            ChangeTitle(title);
            ChangeDate(date);
            ChangeRating(1);
        }

        public override string ToString() =>
            $"[Подія] {_title} | Вартість: {_price:C} | Дата події: {_date:dd.MM.yyyy}";
    }
}