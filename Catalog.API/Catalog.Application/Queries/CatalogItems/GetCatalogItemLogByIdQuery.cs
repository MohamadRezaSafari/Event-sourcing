using MediatR;

namespace Catalog.Application.Queries.CatalogItems;

public class GetCatalogItemLogByIdQuery : IRequest<List<object>>
{
    public GetCatalogItemLogByIdQuery(Guid catalogItemId)
    {
        CatalogItemId = catalogItemId;
    }

    public Guid CatalogItemId { get; private set; }
}