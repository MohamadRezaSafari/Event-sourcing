using MediatR;

namespace Catalog.Application.Commands.CatalogItems;

public class UpdateCatalogItemCommand : INotification
{
    // Update Catalog Item Command
    public UpdateCatalogItemCommand(Guid id, string name, string description,
        double price, int availableStock, int restockThreshold,
        int maxStockThreshold, bool onReorder)
    {
        CatalogItemId = id;
        Name = name;
        Description = description;
        Price = price;
        AvailableStock = availableStock;
        RestockThreshold = restockThreshold;
        MaxStockThreshold = maxStockThreshold;
        OnReorder = onReorder;
    }

    public Guid CatalogItemId { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public double Price { get; private set; }
    public int AvailableStock { get; private set; }
    public int RestockThreshold { get; private set; }
    public int MaxStockThreshold { get; private set; }
    public bool OnReorder { get; private set; }
}