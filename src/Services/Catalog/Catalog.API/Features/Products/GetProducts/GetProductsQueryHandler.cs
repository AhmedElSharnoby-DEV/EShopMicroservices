using BuildingBlocks.CQRS;
using Catalog.API.Models;
using Mapster;
using MapsterMapper;
using Marten;
using Marten.Pagination;

namespace Catalog.API.Features.Products.GetProducts
{
    public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, IEnumerable<GetProductsResult>>
    {
        private readonly IDocumentSession _session;
        public GetProductsQueryHandler(IDocumentSession session)
        {
            _session = session;
        }
        public async Task<IEnumerable<GetProductsResult>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _session.Query<Product>().ToPagedListAsync(request.PageNumber, request.PageSize, cancellationToken);
            return products.Adapt<IEnumerable<GetProductsResult>>() ;
        }
    }
}
