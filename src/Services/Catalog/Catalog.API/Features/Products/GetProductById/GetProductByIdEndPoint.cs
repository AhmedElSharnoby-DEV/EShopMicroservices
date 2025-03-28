using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Features.Products.GetProductById
{
    public class GetProductByIdEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/get-product-by-id", async ([FromQuery] GetProductByIdQuery query, ISender sender) =>
            {
                return await sender.Send(query);
            });
        }
    }
}
