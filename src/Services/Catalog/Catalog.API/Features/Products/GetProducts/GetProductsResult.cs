﻿namespace Catalog.API.Features.Products.GetProducts
{
    public class GetProductsResult
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal Price { get; set; }
        public List<string> Categories { get; set; } = null!;
    }
}
