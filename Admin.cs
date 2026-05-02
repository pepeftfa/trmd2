using System;
using System.Collections.Generic;
using System.Text;

namespace misto
{
    internal class Admin : User
    {
        // Конструктор адміна
        public Admin(string username, string email)
            : base(username, email, UserRole.Admin)
        { }

        // --- МЕТОДИ КЕРУВАННЯ ---

        /// <summary>
        /// Підтвердити профіль організатора
        /// </summary>
        public void VerifyOrganizer(Organizer organizer)
        {
            if (organizer == null) return;

            organizer.Verify();
        
        }

        public void DeleteReview(List<Review> allReviews, Review reviewToDelete)
        {
            if (allReviews.Contains(reviewToDelete))
            {
                allReviews.Remove(reviewToDelete);
              
            }
        }

        public void SetUserRole(User user, UserRole newRole)
        {
            // Тут ми використовуємо той метод ChangeRole, про який говорили раніше
            // або просто змінюємо, якщо сетер дозволяє адміну це робити
            user.ChangeRole(this, newRole);
        }

        public override string ToString()
        {
            return $"Адміністратор системи: {Username} ({Email})";
        }
    }
}