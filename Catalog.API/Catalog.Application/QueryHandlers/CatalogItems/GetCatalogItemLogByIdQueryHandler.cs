using Catalog.Application.Common.Interfaces;
using Catalog.Application.Queries.CatalogItems;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.QueryHandlers.CatalogItems;

public class GetCatalogItemLogByIdQueryHandler :
    IRequestHandler<GetCatalogItemLogByIdQuery, List<object>>
{
    private readonly IAggregateRepository.IAggregateRepository<CatalogItem, Guid>
        _aggregateRepository;

    public GetCatalogItemLogByIdQueryHandler(
        IAggregateRepository.IAggregateRepository<CatalogItem, Guid> aggregateRepository)
    {
        _aggregateRepository = aggregateRepository;
    }

    public async Task<List<object>> Handle(GetCatalogItemLogByIdQuery request,
        CancellationToken cancellationToken)
    {
        var data = await _aggregateRepository
            .ReadEventsAsync(request.CatalogItemId, cancellationToken);

        return data.Values.ToList();
    }
}