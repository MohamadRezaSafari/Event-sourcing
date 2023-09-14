using Catalog.Application.Commands.CatalogItems;
using Catalog.Application.Common.Interfaces;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.CommandHandlers.CatalogItems;

public class DeleteCatalogItemCommandHandler : INotificationHandler<DeleteCatalogItemCommand>
{
    private readonly IAggregateRepository.IAggregateRepository<CatalogItem, Guid>
        _aggregateRepository;

    private readonly ICatalogItemRepository _catalogItemRepository;

    public DeleteCatalogItemCommandHandler(
        IAggregateRepository.IAggregateRepository<CatalogItem, Guid> agrregateRepository
        , ICatalogItemRepository catalogItemRepository)
    {
        _aggregateRepository = agrregateRepository;
        _catalogItemRepository = catalogItemRepository;
    }

    public async Task Handle(DeleteCatalogItemCommand notification,
        CancellationToken cancellationToken)
    {
        var catalogItem = await _aggregateRepository
            .RehydrateAsync(notification.Id, cancellationToken);

        if (catalogItem is null)
            throw new Exception("Invalid Catalog Item information");

        catalogItem.Delete(catalogItem.Id);
        await _aggregateRepository.AppendAsync(catalogItem, cancellationToken);
        await _catalogItemRepository.UpdateAsync(catalogItem);
    }
}