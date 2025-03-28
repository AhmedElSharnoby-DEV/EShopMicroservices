using BuildingBlocks.CQRS;

namespace Catalog.API.Features.Products.UpdateProduct
{
    public class UpdateProductCommand : ICommand<UpdateProductCommandResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public List<string> Categories { get; set; } = null!;
    }
}
