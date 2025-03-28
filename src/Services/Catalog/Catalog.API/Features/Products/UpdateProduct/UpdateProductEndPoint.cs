using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Features.Products.UpdateProduct
{
    public class UpdateProductEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/updte-product", async ([FromBody] UpdateProductCommand command, ISender sender) =>
            {
                return await sender.Send(command);
            });
        }
    }
}
