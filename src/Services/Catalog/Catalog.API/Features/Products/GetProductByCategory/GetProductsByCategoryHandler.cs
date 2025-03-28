using BuildingBlocks.CQRS;
using Catalog.API.Models;
using Mapster;
using Marten;
using System.Linq;

namespace Catalog.API.Features.Products.GetProductByCategory
{
    public class GetProductsByCategoryHandler : IQueryHandler<GetProductsByCategoryQuery, IEnumerable<GetProductsByCategoryResult>>
    {
        private readonly IDocumentSession _session;

        public GetProductsByCategoryHandler(IDocumentSession session)
        {
            _session = session;
        }
        public async Task<IEnumerable<GetProductsByCategoryResult>> Handle(GetProductsByCategoryQuery request, CancellationToken cancellationToken)
        {
            // add validation

            var products = await _session.Query<Product>()
                .Where(x => x.Categories.Contains(request.Category))
                .ToListAsync();
            return products.Adapt<IEnumerable<GetProductsByCategoryResult>>();
        }
    }
}
