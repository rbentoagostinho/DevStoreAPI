using MediatR;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Products.GetAllProducts;

public class GetAllProductsCommand : IRequest<IEnumerable<Product>>
{
    public int Page { get; }
    public int Size { get; }
    public string Order { get; }

    public GetAllProductsCommand(int page, int size, string order)
    {
        Page = page;
        Size = size;
        Order = order;
    }
}