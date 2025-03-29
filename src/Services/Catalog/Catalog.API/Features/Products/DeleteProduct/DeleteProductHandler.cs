using BuildingBlocks.CQRS;
using Catalog.API.Models;
using Marten;
using Microsoft.VisualBasic;

namespace Catalog.API.Features.Products.DeleteProduct
{
    public class DeleteProductHandler : ICommandHandler<DeleteProductCommand, Guid>
    {
        private readonly IDocumentSession _session;

        public DeleteProductHandler(IDocumentSession session)
        {
            _session = session;
        }
        public async Task<Guid> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            // add validation
            var product = await _session.LoadAsync<Product>(request.Id);
            if (product is null)
            {
                throw new Exception("Not Found Product");
            }
            _session.Delete<Product>(request.Id);
            await _session.SaveChangesAsync();
            return product.Id;
        }
    }
}
