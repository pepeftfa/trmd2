using System;
using System.Collections.Generic;
using System.Text;

namespace misto
{
    internal class Order
    {
        public Guid Id { get; init;} = Guid.NewGuid();
        public Guid UserId { get; init;}
        public DateTime OrderDate { get; init;} = DateTime.Now;

        public Event Event { get; init; }

        public OrderStatus Status { get; private set;} = OrderStatus.Pending;

        public enum OrderStatus
        {
            Pending,
            Completed,
            Canceled
        }

        public Order(Guid userId, Event @event)
        {
            UserId = userId;
            Event = @event ?? throw new ArgumentNullException(nameof(@event));
        }

        public void Cancel()
        {
            if (Status == OrderStatus.Canceled)
                throw new InvalidOperationException("Замовлення вже скасовано."); 
            if ((Event.Date - DateTime.Now).TotalHours < 1)
                throw new InvalidOperationException("Запізно для скасування.");
            if (Event == null)
                throw new InvalidOperationException("Неможливо скасувати замовлення, яке не прив'язане до події.");

            Status = OrderStatus.Canceled;
        }
        public void Complete()
        {
            if (Status != OrderStatus.Pending)
                throw new InvalidOperationException("Можна завершити тільки замовлення, що очікують.");

            Status = OrderStatus.Completed;
        }

        public bool IsCompleted => Status == OrderStatus.Completed;
        public bool IsCanceled => Status == OrderStatus.Canceled;

    }
}
