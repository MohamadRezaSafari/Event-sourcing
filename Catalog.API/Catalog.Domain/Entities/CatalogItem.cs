using Catalog.Domain.Entities.Common;
using Catalog.Domain.Events.CatalogItems;

namespace Catalog.Domain.Entities;

public class CatalogItem : BaseAggregateRoot<CatalogItem, Guid>
{
    private CatalogItem() { }

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

    public static CatalogItem Create(string name, string description, double price,
        int availableStock, int restockThreshold, int maxStockThreshold, bool onReorder)
    {
        return new CatalogItem(Guid.NewGuid(), name, description, price,
            availableStock, restockThreshold, maxStockThreshold, onReorder);
    }

    public void Update(Guid id, string name, string description, double price,
        int availableStock, int restockThreshold, int maxStockThreshold, bool onReorder)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        AvailableStock = availableStock;
        RestockThreshold = restockThreshold;
        MaxStockThreshold = maxStockThreshold;
        OnReorder = onReorder;

        AddEvent(new CatalogItemUpdated(this));
    }

    public void Delete(Guid id)
    {
        Id = id;
        IsDeleted = true;

        AddEvent(new CatalogItemDeleted(this));
    }

    protected override void Apply(IDomainEvent<Guid> @event)
    {
        switch (@event)
        {
            case CatalogItemCreated catalogItemCreated:
                OnCatalogItemCreated(catalogItemCreated);
                break;
            case CatalogItemUpdated catalogItemUpdated:
                OnCatalogItemUpdated(catalogItemUpdated);
                break;
            case CatalogItemDeleted catalogItemDeleted:
                IsDeleted = catalogItemDeleted.IsDeleted;
                break;
        }
    }

    private void OnCatalogItemUpdated(CatalogItemUpdated catalogItemUpdated)
    {
        Name = catalogItemUpdated.Name;
        Description = catalogItemUpdated.Description;
        Price = catalogItemUpdated.Price;
        AvailableStock = catalogItemUpdated.AvailableStock;
        RestockThreshold = catalogItemUpdated.RestockThreshold;
        MaxStockThreshold = catalogItemUpdated.MaxStockThreshold;
        OnReorder = catalogItemUpdated.OnReorder;
    }

    private void OnCatalogItemCreated(CatalogItemCreated catalogItemCreated)
    {
        Id = catalogItemCreated.AggregateId;
        Name = catalogItemCreated.Name;
        Description = catalogItemCreated.Description;
        Price = catalogItemCreated.Price;
        AvailableStock = catalogItemCreated.AvailableStock;
        RestockThreshold = catalogItemCreated.RestockThreshold;
        MaxStockThreshold = catalogItemCreated.MaxStockThreshold;
        OnReorder = catalogItemCreated.OnReorder;
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