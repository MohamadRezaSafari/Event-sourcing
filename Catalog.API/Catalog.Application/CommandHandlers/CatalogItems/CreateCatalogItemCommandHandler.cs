using Catalog.Application.Commands.CatalogItems;
using Catalog.Application.Common.Interfaces;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.CommandHandlers.CatalogItems;

public class CreateCatalogItemCommandHandler : INotificationHandler<CreateCatalogItemCommand>
{
    private readonly IAggregateRepository.IAggregateRepository<CatalogItem, Guid>
        _aggregateRepository;
    private readonly ICatalogItemRepository _catalogItemRepository;

    public CreateCatalogItemCommandHandler(
        IAggregateRepository.IAggregateRepository<CatalogItem, Guid> aggregateRepository,
        ICatalogItemRepository catalogItemRepository)
    {
        _aggregateRepository = aggregateRepository;
        _catalogItemRepository = catalogItemRepository;
    }

    public async Task Handle(CreateCatalogItemCommand notification,
        CancellationToken cancellationToken)
    {
        var catalogItem = CatalogItem.Create(
            notification.Name, notification.Description,
            notification.Price, notification.AvailableStock,
            notification.RestockThreshold, notification.MaxStockThreshold,
            notification.OnReorder);

        await _aggregateRepository.AppendAsync(catalogItem, cancellationToken);
        await _catalogItemRepository.AddAsync(catalogItem);
    }
}