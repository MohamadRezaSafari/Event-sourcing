using Event_Sourcing_with_CQRS.Events;
using Event_Sourcing_with_CQRS.Infrastructure.DbContexts;
using MediatR;

namespace Event_Sourcing_with_CQRS.Infrastructure
{
    public class ProductCreatedEventHandler : INotificationHandler<ProductCreatedEvent>
    {
        private readonly AppReadDbContext _context;

        public ProductCreatedEventHandler(AppReadDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ProductCreatedEvent notification,
            CancellationToken cancellationToken)
        {
            var product = new ProductReadModel
            {
                Id = notification.ProductId,
                Name = notification.Name,
                Price = notification.Price
            };

            _context.ProductReadModels.Add(product);
            await _context.SaveChangesAsync();
        }
    }
}
