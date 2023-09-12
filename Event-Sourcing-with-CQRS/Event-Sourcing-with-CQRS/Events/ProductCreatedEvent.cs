using MediatR;

namespace Event_Sourcing_with_CQRS.Events
{
    public class ProductCreatedEvent : INotification
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsReplay { get; set; }
    }
}
