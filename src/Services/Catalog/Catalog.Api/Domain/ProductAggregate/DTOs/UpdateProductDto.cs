using Catalog.API.Domain.CategoryAggregate.Models;

namespace Catalog.API.Domain.ProductAggregate.DTOs
{
    public class UpdateProductDto
    {
        public string NameEn { get; set; } = null!;
        public string NameAr { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public DateTime ProductionDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public List<Category> Categories { get; set; } = new();
    }
}
