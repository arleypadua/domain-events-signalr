using MediatR;
using Ordering.Schema.Commands;
using Ordering.Schema.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Service.Handlers
{
    public class PlaceOrderRequestHandler : IRequestHandler<PlaceOrderCommand>
    {
        private readonly IMediator _mediator;

        public PlaceOrderRequestHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Unit> Handle(PlaceOrderCommand request, CancellationToken cancellationToken)
        {
            // Manipulate your domain object
            // Persist it
            // Publish events

            // Wait for the matter of the example
            await Task.Delay(2000, cancellationToken);

            await _mediator.Publish(new OrderPlacedEvent { OrderId = Guid.NewGuid() }, cancellationToken);
            
            return Unit.Value;
        }
    }
}