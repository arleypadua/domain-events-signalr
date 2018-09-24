using System;
using MediatR;

namespace Ordering.Schema.Events
{
    public class OrderPlacedEvent : INotification
    {
        public Guid OrderId { get; set; }
    }
}