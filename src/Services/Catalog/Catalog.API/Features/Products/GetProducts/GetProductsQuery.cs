using BuildingBlocks.CQRS;

namespace Catalog.API.Features.Products.GetProducts
{
    public class GetProductsQuery : IQuery<IEnumerable<GetProductsResult>>
    {
    }
}
