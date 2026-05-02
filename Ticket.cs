using System;
using System.Collections.Generic;
using System.Text;

namespace misto
{
    internal class Ticket
    {
        private decimal _price = 0;

        public enum TicketStatus { Available, Reserved, Sold } 
        public TicketStatus Status { get; private set; } = TicketStatus.Available;

        public Guid TicketId { get; init; } = Guid.NewGuid();
        public Guid EventId { get; init; }
        public Guid UserId { get; set; }
        public decimal Price { get; private set; }
        public bool IsSold { get; set; } = false;

        public void Confirm()
        {
            Status = TicketStatus.Sold;
            IsSold = true;
        }



    }
}
