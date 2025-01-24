using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for SaleItem entity operations
/// </summary>
public interface ISaleItemRepository
{
    Task<SaleItem> CreateAsync(SaleItem saleItem);
    Task<SaleItem?> GetByIdAsync(Guid id);
    Task<IEnumerable<SaleItem>> GetAllAsync(int _page = 1, int _size = 10, string _order = "");
    Task<SaleItem> UpdateAsync(SaleItem saleItem);
    Task<bool> DeleteAsync(Guid id);
}




