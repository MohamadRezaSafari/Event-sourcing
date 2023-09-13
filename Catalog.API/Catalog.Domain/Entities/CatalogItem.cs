using Catalog.Domain.Entities.Common;
using Catalog.Domain.Events.CatalogItems;

namespace Catalog.Domain.Entities;

public class CatalogItem : BaseAggregateRoot<CatalogItem, Guid>
{
    public CatalogItem(Guid id, string name, string description,
        double price, int availableStock, int restockThreshold,
        int maxStockThreshold, bool onReorder) : base(id)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        AvailableStock = availableStock;
        RestockThreshold = restockThreshold;
        MaxStockThreshold = maxStockThreshold;
        OnReorder = onReorder;
        
        if (Version > 0)
            throw new Exception("Catalog item already created");
        
        if (string.IsNullOrEmpty(name))
            throw new Exception("Name Can not be Empty");
        
        if (price <= 0)
            throw new Exception("Price must be positive value");
        
        AddEvent(new CatalogItemCreated(this));
    }

    protected override void Apply(IDomainEvent<Guid> @event)
    {
        throw new NotImplementedException();
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public double Price { get; private set; }
    public int AvailableStock { get; private set; }
    public int RestockThreshold { get; private set; }
    public int MaxStockThreshold { get; private set; }
    public bool OnReorder { get; private set; }
    public bool IsDeleted { get; private set; } = false;
}