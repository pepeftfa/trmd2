using System;
using System.Collections.Generic;
using System.Text;

namespace misto
{
    internal class Location
    {
        public Guid Id { get; init; }= Guid.NewGuid();
        private string _address = string.Empty;
        public string Address
        {
            get => _address;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Не може бути порожнім!");
                _address = value;
            }
        }
        public string City { get; init; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }


        public override string ToString() => $"{City}, {Address}";
    }
}
