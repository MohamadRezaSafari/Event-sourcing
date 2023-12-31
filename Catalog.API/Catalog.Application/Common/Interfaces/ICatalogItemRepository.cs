﻿using Catalog.Domain.Entities;

namespace Catalog.Application.Common.Interfaces;

public interface ICatalogItemRepository
{
    Task<IEnumerable<CatalogItem>> GetCustomersAsync();
    Task AddAsync(CatalogItem catalogItem);
    Task UpdateAsync(CatalogItem catalogItem);
}