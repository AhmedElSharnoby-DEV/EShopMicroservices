namespace Catalog.API.Features.Products.GetProductByCategory
{
    public class GetProductsByCategoryResult
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public List<string> Categories { get; set; } = null!;
    }
}
