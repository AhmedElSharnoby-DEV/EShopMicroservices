using BuildingBlocks.CQRS;
using Catalog.API.Models;
using Mapster;
using Marten;
using Microsoft.AspNetCore.Http;

namespace Catalog.API.Features.Products.GetProductById
{
    public class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        private readonly IDocumentSession _session;

        public GetProductByIdQueryHandler(IDocumentSession session)
        {
            _session = session;
        }
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            // add validation
            var product = await _session.LoadAsync<Product>(request.Id);
            if(product is null)
            {
                throw new Exception("Not Found Product");
            }
            return product.Adapt<GetProductByIdResult>();
        }
    }
}
