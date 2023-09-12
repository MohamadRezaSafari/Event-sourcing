using MediatR;

namespace Event_Sourcing_with_CQRS.Domain.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
