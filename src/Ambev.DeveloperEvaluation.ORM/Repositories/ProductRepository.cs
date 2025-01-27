using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of IProductRepository using Entity Framework Core
/// </summary>
public class ProductRepository : IProductRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of ProductRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public ProductRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new product in the database
    /// </summary>
    /// <param name="product">The product to create</param>
    /// <returns>The created product</returns>
    public async Task<Product> CreateAsync(Product product)
    {
        await _context.Set<Product>().AddAsync(product);
        await _context.SaveChangesAsync();
        return product;
    }

    /// <summary>
    /// Retrieves a product by its unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the product</param>
    /// <returns>The product if found, null otherwise</returns>
    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await _context.Set<Product>().FirstOrDefaultAsync(p => p.Id == id);
    }

    /// <summary>
    /// Retrieves all products with pagination and optional ordering
    /// </summary>
    /// <param name="_page">The page number</param>
    /// <param name="_size">The page size</param>
    /// <param name="_order">The order by clause</param>
    /// <returns>A list of products</returns>
    public async Task<IEnumerable<Product>> GetAllAsync(int _page = 1, int _size = 10, string _order = "", CancellationToken cancellationToken = default)
    {
        var query = _context.Products.AsQueryable();

        return await query
        .Skip((_page - 1) * _size)
        .Take(_size)
        .ToListAsync();
    }

    /// <summary>
    /// Updates an existing product in the database
    /// </summary>
    /// <param name="product">The product to update</param>
    /// <returns>The updated product</returns>
    public async Task<Product> UpdateAsync(Product product)
    {
        _context.Set<Product>().Update(product);
        await _context.SaveChangesAsync();
        return product;
    }

    /// <summary>
    /// Deletes a product from the database
    /// </summary>
    /// <param name="id">The unique identifier of the product to delete</param>
    /// <returns>True if the product was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(Guid id)
    {
        var product = await GetByIdAsync(id);
        if (product == null)
            return false;

        _context.Set<Product>().Remove(product);
        await _context.SaveChangesAsync();
        return true;
    }
}
