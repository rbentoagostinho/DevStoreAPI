using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for Sale entity operations
/// </summary>
public interface ISaleRepository
{
    Task<Sale> CreateAsync(Sale sale);
    Task<Sale?> GetByIdAsync(Guid id);
    Task<IEnumerable<Sale>> GetAllAsync(int _page = 1, int _size = 10, string _order = "");    
}




