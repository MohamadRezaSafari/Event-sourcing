using MediatR;

namespace Event_Sourcing_with_CQRS.Domain.Events
{
    public class ProductCreatedEvent : INotification
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
