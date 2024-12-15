namespace Catalog.API.Features.Products.AddProduct
{
    public class AddProductCommand : ICommand<Response<ProductResponseDto>>
    {
        public string NameEn { get; set; } = null!;
        public string NameAr { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public DateTime ProductionDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public List<long> Categories { get; set; } = new();

        //public string CreatedBy { get; set; } = null!;
    }
}
