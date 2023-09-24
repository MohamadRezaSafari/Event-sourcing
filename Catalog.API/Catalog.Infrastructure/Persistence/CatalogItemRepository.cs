using Catalog.Application.Common.Interfaces;
using Catalog.Domain.Entities;

namespace Catalog.Infrastructure.Persistence;

public class CatalogItemRepository : ICatalogItemRepository
{
    private readonly ApplicationDbContext _context;

    public CatalogItemRepository(ApplicationDbContext applicationDbContext)
    {
        _context = applicationDbContext;
    }

    public async Task AddAsync(CatalogItem catalogItem)
    {
        await _context.AddAsync(catalogItem);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<CatalogItem>> GetCustomersAsync()
    {
        var result = _context.CatalogItems.AsEnumerable();

        return result;
    }

    public async Task UpdateAsync(CatalogItem catalogItem)
    {
        _context.Entry(catalogItem).State =
            Microsoft.EntityFrameworkCore.EntityState.Modified;

        await _context.SaveChangesAsync();
    }
}