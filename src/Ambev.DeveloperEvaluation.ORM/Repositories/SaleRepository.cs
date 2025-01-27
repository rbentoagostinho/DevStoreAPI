using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Implementation of ISaleRepository using Entity Framework Core
    /// </summary>
    public class SaleRepository : ISaleRepository
    {
        private readonly DefaultContext _context;

        /// <summary>
        /// Initializes a new instance of SaleRepository
        /// </summary>
        /// <param name="context">The database context</param>
        public SaleRepository(DefaultContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new sale in the database
        /// </summary>
        /// <param name="sale">The sale to create</param>
        /// <returns>The created sale</returns>
        public async Task<Sale> CreateAsync(Sale sale)
        {
            await _context.Set<Sale>().AddAsync(sale);
            await _context.SaveChangesAsync();
            return sale;
        }

        /// <summary>
        /// Retrieves a sale by its unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the sale</param>
        /// <returns>The sale if found, null otherwise</returns>
        public async Task<Sale?> GetByIdAsync(Guid id)
        {
            return await _context.Set<Sale>()
                .Include(s => s.Items) // Incluindo os itens da venda, se necessário
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        /// <summary>
        /// Retrieves all sales with pagination and optional ordering
        /// </summary>
        /// <param name="_page">The page number</param>
        /// <param name="_size">The page size</param>
        /// <param name="_order">The order by clause</param>
        /// <returns>A list of sales</returns>
        public async Task<IEnumerable<Sale>> GetAllAsync(int _page = 1, int _size = 10, string _order = "")
        {
            var query = _context.Sales.AsQueryable();

            // Implementação do ordenamento, se necessário
            if (!string.IsNullOrEmpty(_order))
            {
                // Exemplo de ordenação, pode ser expandido conforme necessidade
                if (_order.Equals("SaleDate", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.OrderBy(s => s.SaleDate);
                }
            }

            return await query
                .Skip((_page - 1) * _size)
                .Take(_size)
                .ToListAsync();
        }

    }
}
