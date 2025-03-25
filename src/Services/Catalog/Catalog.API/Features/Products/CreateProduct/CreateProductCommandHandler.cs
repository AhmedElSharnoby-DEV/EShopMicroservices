using BuildingBlocks.CQRS;
using Catalog.API.Models;
using Mapster;
using Marten;

namespace Catalog.API.Features.Products.CreateProduct
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly IDocumentSession _session;

        public CreateProductCommandHandler(IDocumentSession session)
        {
            _session = session;
        }
        public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // create product entity
            var product = new Product()
            {
                Name = request.Name,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                Price = request.Price,
                Categories = request.Categories
            };

            // save to database
            _session.Store(product);
            await _session.SaveChangesAsync();

            // return result
            var response = product.Adapt<CreateProductResult>();
            return response;
        }
    }
}
