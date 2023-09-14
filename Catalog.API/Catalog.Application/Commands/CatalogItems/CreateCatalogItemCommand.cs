using MediatR;

namespace Catalog.Application.Commands.CatalogItems;

public class CreateCatalogItemCommand : INotification
{
    public CreateCatalogItemCommand(string name, string description, double price,
        int availableStock, int restockThreshold,
        int maxStockThreshold, bool onReorder)
    {
        Name = name;
        Description = description;
        Price = price;
        AvailableStock = availableStock;
        RestockThreshold = restockThreshold;
        MaxStockThreshold = maxStockThreshold;
        OnReorder = onReorder;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public double Price { get; private set; }
    public int AvailableStock { get; private set; }
    public int RestockThreshold { get; private set; }
    public int MaxStockThreshold { get; private set; }
    public bool OnReorder { get; private set; }
}