using BuildingBlocks.CQRS;
using Catalog.API.Models;
using Marten;

namespace Catalog.API.Features.Products.UpdateProduct
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, UpdateProductCommandResult>
    {
        private readonly IDocumentSession _session;

        public UpdateProductCommandHandler(IDocumentSession session)
        {
            _session = session;
        }
        public async Task<UpdateProductCommandResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            // add validation
            var product = await _session.LoadAsync<Product>(request.Id);
            if(product is null)
            {
                throw new Exception("Not Found Product");
            }
            product.Name = request.Name;
            product.Description = request.Description;
            product.ImageUrl = request.ImageUrl;
            product.Price = request.Price;
            product.Categories.Clear();
            product.Categories.AddRange(request.Categories);
            _session.Update(product);
            await _session.SaveChangesAsync();
            return new UpdateProductCommandResult() { Id = request.Id };
        }
    }
}
