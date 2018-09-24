using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Ordering.Schema.Events;

namespace Ordering.Api.RealTime
{
    public class OrderingEventsClientDispatcher : INotificationHandler<OrderPlacedEvent>
    {
        private readonly IHubContext<OrderingEventsClientHub> _hubContext;

        public OrderingEventsClientDispatcher(IHubContext<OrderingEventsClientHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public Task Handle(OrderPlacedEvent @event, CancellationToken cancellationToken)
        {
            // Ideally this should send this event only to clients interested on this event. Possibly based on the current user.
            return _hubContext.Clients.All.SendAsync("orderPlaced", @event, cancellationToken);
        }
    }
}