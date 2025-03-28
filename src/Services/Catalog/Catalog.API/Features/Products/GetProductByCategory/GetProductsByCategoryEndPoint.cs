using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Features.Products.GetProductByCategory
{
    public class GetProductsByCategoryEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/get-product-by-category", async ([FromQuery] GetProductsByCategoryQuery query, ISender sender) =>
            {
                return await sender.Send(query);
            });
        }
    }
}
