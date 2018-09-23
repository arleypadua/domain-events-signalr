using MediatR;

namespace Ordering.Schema.Commands
{
    public class PlaceOrderCommand : IRequest
    {
        public string CustomerName { get; set; }
        public OrderLine[] OrderLines { get; set; }

        public class OrderLine
        {
            public string ProductName { get; set; }
            public int Quantity { get; set; }
        }
    }
}



