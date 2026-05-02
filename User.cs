using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace misto
{
    internal class User
    {
        private string _username = string.Empty;
        private string _email = string.Empty;
        private string _password = string.Empty;
        private DateTime _dateOfBirth = DateTime.MinValue;
        public Guid Id { get; init; } = Guid.NewGuid();
        public UserRole Role { get; set; }
        public enum UserRole
        {
            Guest,
            User,
            Organizer,
            Admin
        }



        public string Username
        {
            get => _username;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Ім'я користувача не може бути порожнім.");
                _username = value;
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Не може бути порожнім!");
                if (!value.Contains("@"))
                    throw new ArgumentException("Некоректний формат Email.");

                    _email = value;
 
            }
        }
        public bool ValidateEmail(string Email)
        {
            return Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }


        public string Password
         {
             get => _password;
             set
             {
                 if (string.IsNullOrWhiteSpace(value))
                     throw new ArgumentException("Не може бути порожнім!");
                if (value.Length < 8)
                    throw new ArgumentException("Пароль повинен містити не менше 8 літер!");
                if (!value.Any(char.IsUpper))
                    throw new ArgumentException("Пароль повинен містити хоча б одну велику літеру!");
                if (!value.Any(char.IsDigit))
                    throw new ArgumentException("Пароль має містити хоча б одну цифру.");


                _password = value;
            }
        
        }
        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Дата народження не може бути в майбутньому");
                _dateOfBirth = value;
            }
        }
        public string DateOfBirthFormatted => _dateOfBirth.ToString("dd.MM.yyyy");


        public DateTime RegistrationDate { get; init; } = DateTime.Now;
        public DateTime DateOfLastActivity { get; set; }
        public void UpdateActivity()
        {
            DateOfLastActivity = DateTime.Now;
        }


        public UserSex Sex { get; set; }
        public enum UserSex
        {
            Чоловік,
            Жінка
        }

        public double CalculateAverageRating(List<Review> reviews)
        {
            var userReviews = reviews.Where(r => r.UserId == Id).ToList();

            if (!userReviews.Any())
                return 0;

            return userReviews.Average(r => r.Rating);
        }

        public User(string username, string email, UserRole role = UserRole.Guest)
        {
            Username = username;
            Email = email;
            Role = role;
        }
        public void ChangeRole(Admin admin, UserRole newRole)
        {
            if (admin == null)
                throw new ArgumentNullException(nameof(admin));

            // Оскільки цей метод викликається у об'єкта 'user', 
            // ми просто присвоюємо йому нову роль.
            this.Role = newRole;
        }
    }
}
