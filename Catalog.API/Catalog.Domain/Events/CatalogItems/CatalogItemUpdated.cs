﻿using Catalog.Domain.Entities;
using Catalog.Domain.Entities.Common;

namespace Catalog.Domain.Events.CatalogItems;

public class CatalogItemUpdated : BaseDomainEvent<CatalogItem, Guid>
{
    private CatalogItemUpdated()
    {
    }

    public CatalogItemUpdated(CatalogItem catalogItem) : base(catalogItem)
    {
        Name = catalogItem.Name;
        Description = catalogItem.Description;
        Price = catalogItem.Price;
        AvailableStock = catalogItem.AvailableStock;
        RestockThreshold = catalogItem.RestockThreshold;
        MaxStockThreshold = catalogItem.MaxStockThreshold;
        OnReorder = catalogItem.OnReorder;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public double Price { get; private set; }
    public int AvailableStock { get; private set; }
    public int RestockThreshold { get; private set; }
    public int MaxStockThreshold { get; private set; }
    public bool OnReorder { get; private set; }
}