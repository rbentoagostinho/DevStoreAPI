using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Implementation of ISaleItemRepository using Entity Framework Core
    /// </summary>
    public class SaleItemRepository : ISaleItemRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of SaleItemRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public SaleItemRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new sale item in the database
        /// </summary>
        /// <param name="saleItem">The sale item to create</param>
        /// <returns>The created sale item</returns>
        public async Task<SaleItem> CreateAsync(SaleItem saleItem)
        {
            await _context.Set<SaleItem>().AddAsync(saleItem);
            await _context.SaveChangesAsync();
            return saleItem;
        }

        /// <summary>
        /// Retrieves a sale item by its unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the sale item</param>
        /// <returns>The sale item if found, null otherwise</returns>
        public async Task<SaleItem?> GetByIdAsync(Guid id)
        {
            return await _context.Set<SaleItem>()
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        /// <summary>
        /// Retrieves all sale items associated with a sale by saleId
        /// </summary>
        /// <param name="saleId">The unique identifier of the sale</param>
        /// <returns>A list of sale items</returns>
        public async Task<IEnumerable<SaleItem>> GetBySaleIdAsync(Guid saleId)
        {
            return await _context.Set<SaleItem>()
                .Where(s => s.SaleId == saleId)
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves all sale items with pagination and optional ordering
        /// </summary>
        /// <param name="_page">The page number</param>
        /// <param name="_size">The page size</param>
        /// <param name="_order">The order by clause</param>
        /// <returns>A list of sale items</returns>
        public async Task<IEnumerable<SaleItem>> GetAllAsync(int _page = 1, int _size = 10, string _order = "")
        {
            var query = _context.SaleItems.AsQueryable();

            // Implementação do ordenamento, se necessário
            if (!string.IsNullOrEmpty(_order))
            {
                // Exemplo de ordenação, pode ser expandido conforme necessidade
                if (_order.Equals("ProductName", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.OrderBy(s => s.ProductName);
                }
            }

            return await query
                .Skip((_page - 1) * _size)
                .Take(_size)
                .ToListAsync();
        }     

      
    }
}
