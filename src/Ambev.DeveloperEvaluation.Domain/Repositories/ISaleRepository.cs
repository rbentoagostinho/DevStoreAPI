// Domain/Repositories/ISaleRepository.cs
using Ambev.DeveloperEvaluation.Domain.Entities;

public interface ISaleRepository
{
    Task<Sale> CreateAsync(Sale sale);
    Task<Sale?> GetByIdAsync(Guid id);
    Task<Sale?> GetByNumberAsync(string saleNumber);
    Task<IEnumerable<Sale>> GetAllAsync(int page = 1, int size = 10, CancellationToken cancellationToken = default);
    Task<Sale> UpdateAsync(Sale sale);
    Task<bool> DeleteAsync(Guid id);
    Task<bool> CancelSaleAsync(Guid id);
}