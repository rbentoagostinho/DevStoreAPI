// Infrastructure/Repositories/SaleRepository.cs
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.ORM;
using Microsoft.EntityFrameworkCore;

public class SaleRepository : ISaleRepository
{
    private readonly DefaultContext _context;

    public SaleRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<Sale> CreateAsync(Sale sale)
    {
        sale.CreatedAt = DateTime.UtcNow;
        sale.SaleNumber = await GenerateSaleNumberAsync();
        await _context.Sales.AddAsync(sale);
        await _context.SaveChangesAsync();
        return sale;
    }

    public async Task<Sale?> GetByIdAsync(Guid id)
    {
        return await _context.Sales
            .Include(s => s.Items)
            .ThenInclude(i => i.Product)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Sale?> GetByNumberAsync(string saleNumber)
    {
        return await _context.Sales
            .Include(s => s.Items)
            .ThenInclude(i => i.Product)
            .FirstOrDefaultAsync(s => s.SaleNumber == saleNumber);
    }

    public async Task<IEnumerable<Sale>> GetAllAsync(int page = 1, int size = 10, CancellationToken cancellationToken = default)
    {
        return await _context.Sales
            .Include(s => s.Items)
            .ThenInclude(i => i.Product)
            .OrderByDescending(s => s.SaleDate)
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync(cancellationToken);
    }

    public async Task<Sale> UpdateAsync(Sale sale)
    {
        sale.UpdatedAt = DateTime.UtcNow;
        _context.Sales.Update(sale);
        await _context.SaveChangesAsync();
        return sale;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var sale = await GetByIdAsync(id);
        if (sale == null) return false;

        _context.Sales.Remove(sale);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> CancelSaleAsync(Guid id)
    {
        var sale = await GetByIdAsync(id);
        if (sale == null) return false;

        sale.IsCancelled = true;
        sale.UpdatedAt = DateTime.UtcNow;
        await _context.SaveChangesAsync();
        return true;
    }

    private async Task<string> GenerateSaleNumberAsync()
    {
        var lastSale = await _context.Sales
            .OrderByDescending(s => s.CreatedAt)
            .FirstOrDefaultAsync();

        int nextNumber = 1;
        if (lastSale != null)
        {
            var lastNumber = int.Parse(lastSale.SaleNumber.Split('-')[1]);
            nextNumber = lastNumber + 1;
        }

        return $"SALE-{nextNumber:D6}";
    }
}