using System;
using System.Collections.Generic;
using System.Text;

namespace misto
{
    internal class Organizer : User
    {
        private string _phonenumber = string.Empty;
        public string _companyname = string.Empty;


        public string PhoneNumber
        {
            get => _phonenumber;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Не може бути порожнім!");
                if (value.Length < 10)
                    throw new ArgumentException("Введіть коректний номер телефону!");

                _phonenumber = value;
            }
        }
        public string CompanyName
        {
            get => _companyname;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Не може бути порожнім!");
                _companyname = value;
            }
        }

        public List<Event> MyEvents { get; init; } = new List<Event>();

        public List<Event> GetActiveEvents()
        {
            return MyEvents.Where(e => e.Date > DateTime.Now).ToList();
        }
        public bool IsVerified { get; set; } = false;

        public Organizer(string username, string email, string companyName, string phoneNumber)
            : base(username, email, UserRole.Guest)
        {
            CompanyName = companyName;
            PhoneNumber = phoneNumber;
        }

        public void Verify()
        {
            IsVerified = true;
        }
    }
}
