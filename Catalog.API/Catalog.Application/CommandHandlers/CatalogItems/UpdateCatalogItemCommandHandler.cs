using Catalog.Application.Commands.CatalogItems;
using Catalog.Application.Common.Interfaces;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.CommandHandlers.CatalogItems;

public class UpdateCatalogItemCommandHandler : INotificationHandler<UpdateCatalogItemCommand>
{
    private readonly IAggregateRepository.IAggregateRepository<CatalogItem, Guid>
        _aggregateRepository;

    private readonly ICatalogItemRepository _catalogItemRepository;

    public UpdateCatalogItemCommandHandler(
        IAggregateRepository.IAggregateRepository<CatalogItem, Guid> aggregateRepository,
        ICatalogItemRepository catalogItemRepository)
    {
        _aggregateRepository = aggregateRepository;
        _catalogItemRepository = catalogItemRepository;
    }

    public async Task Handle(UpdateCatalogItemCommand notification,
        CancellationToken cancellationToken)
    {
        var catalogItem = await _aggregateRepository
            .RehydrateAsync(notification.CatalogItemId, cancellationToken);

        if (catalogItem is null)
            throw new Exception("Invalid catalog item information");

        catalogItem.Update(
            notification.CatalogItemId, notification.Name,
            notification.Description, notification.Price,
            notification.AvailableStock, notification.RestockThreshold,
            notification.MaxStockThreshold, notification.OnReorder);

        await _aggregateRepository.AppendAsync(catalogItem, cancellationToken);
        await _catalogItemRepository.UpdateAsync(catalogItem);
    }
}