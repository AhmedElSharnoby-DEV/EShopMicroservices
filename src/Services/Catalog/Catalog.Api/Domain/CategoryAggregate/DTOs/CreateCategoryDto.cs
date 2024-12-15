namespace Catalog.API.Domain.CategoryAggregate.DTOs
{
    public class CreateCategoryDto
    {
        public string NameEn { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string CreatedBy { get; set; } = null!;
    }
}
