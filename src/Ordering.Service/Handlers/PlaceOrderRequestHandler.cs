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
            // Wait for the matter of the example
            // Ideally here you should manipulate your domain object, persist it and publish events.
            await Task.Delay(2000, cancellationToken);

            await _mediator.Publish(new OrderPlacedEvent { OrderId = Guid.NewGuid() }, cancellationToken);
            
            return Unit.Value;
        }
    }
}