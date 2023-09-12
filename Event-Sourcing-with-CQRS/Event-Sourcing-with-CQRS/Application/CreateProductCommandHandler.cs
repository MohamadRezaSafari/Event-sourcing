using Event_Sourcing_with_CQRS.Domain;
using Event_Sourcing_with_CQRS.Domain.Commands;
using Event_Sourcing_with_CQRS.Domain.Events;
using Event_Sourcing_with_CQRS.Infrastructure.DbContexts;
using MediatR;

namespace Event_Sourcing_with_CQRS.Application
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;

        public CreateProductCommandHandler(AppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            if (_context.Database.CanConnect())
            {

            }

            var product = new Product
            {
                Name = command.Name,
                Price = command.Price
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            // Reload the product to get the Id
            await _context.Entry(product).ReloadAsync(cancellationToken);

            var productCreatedEvent = new ProductCreatedEvent
            {
                ProductId = product.Id,
                Name = product.Name,
                Price = product.Price
            };

            await _mediator.Publish(productCreatedEvent);

            return product.Id;
        }
    }
}
