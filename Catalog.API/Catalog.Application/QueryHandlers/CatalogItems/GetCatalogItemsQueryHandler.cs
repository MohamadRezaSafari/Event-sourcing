using Catalog.Application.Common.Interfaces;
using Catalog.Application.Queries.CatalogItems;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.QueryHandlers.CatalogItems;

public class GetCatalogItemsQueryHandler :
    IRequestHandler<GetCatalogItemsQuery, IEnumerable<CatalogItem>>
{
    private readonly ICatalogItemRepository catalogItemRepository;
    private readonly IMediator mediator;
    private readonly IAggregateRepository.IAggregateRepository<CatalogItem, Guid>
        _aggregateRepository;

    public GetCatalogItemsQueryHandler(
        ICatalogItemRepository catalogItemRepository,
        IMediator mediator,
        IAggregateRepository.IAggregateRepository<CatalogItem, Guid> aggregateRepository)
    {
        this.catalogItemRepository = catalogItemRepository;
        this.mediator = mediator;
        _aggregateRepository = aggregateRepository;
    }

    public async Task<IEnumerable<CatalogItem>> Handle(GetCatalogItemsQuery request,
        CancellationToken cancellationToken)
    {
        var data = await catalogItemRepository.GetCustomersAsync();

        return data;
    }
}