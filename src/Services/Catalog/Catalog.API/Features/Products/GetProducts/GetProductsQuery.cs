using BuildingBlocks.CQRS;

namespace Catalog.API.Features.Products.GetProducts
{
    public class GetProductsQuery : IQuery<IEnumerable<GetProductsResult>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
