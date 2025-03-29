using BuildingBlocks.CQRS;

namespace Catalog.API.Features.Products.DeleteProduct
{
    public class DeleteProductCommand : ICommand<Guid>
    {
        public Guid Id { get; set; }
    }
}
