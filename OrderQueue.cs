using System;
using System.Collections.Generic;
using System.Text;

namespace misto
{
    internal class OrderQueue
    {
        private readonly Queue<Order> _ordersToProcess = new();
        public void AddToQueue(Order order)
        {
            if (order == null) 
                throw new ArgumentNullException("Не можна додати ніщо");
            if (order.Status != Order.OrderStatus.Pending)
                throw new InvalidOperationException("Можна обробляти тільки нові замовлення.");

            _ordersToProcess.Enqueue(order);
        }

        public Order ProcessNext()
        {
            if (_ordersToProcess.Count == 0)
                return null;

            Order currentOrder = _ordersToProcess.Dequeue();
            currentOrder.Complete();
            return currentOrder;
        }
        public int Count => _ordersToProcess.Count;
        public bool IsEmpty => _ordersToProcess.Count == 0;

        public void Clear() => _ordersToProcess.Clear();
    }
}
