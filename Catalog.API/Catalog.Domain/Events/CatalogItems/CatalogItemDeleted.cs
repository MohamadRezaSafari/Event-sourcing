using Catalog.Domain.Entities;
using Catalog.Domain.Entities.Common;

namespace Catalog.Domain.Events.CatalogItems;

public class CatalogItemDeleted : BaseDomainEvent<CatalogItem, Guid>
{
    private CatalogItemDeleted()
    {
    }

    public CatalogItemDeleted(CatalogItem catalogItem) : base(catalogItem)
    {
        IsDeleted = catalogItem.IsDeleted;
    }

    public bool IsDeleted { get; private set; }
}