using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.Queries.CatalogItems;

public class GetCatalogItemsQuery : IRequest<IEnumerable<CatalogItem>>
{

}