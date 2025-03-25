using Carter;
using MediatR;

namespace Catalog.API.Features.Products.CreateProduct
{
    public class CreateProductEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/add-product", async (CreateProductCommand request, ISender sender) =>
            {
                return await sender.Send(request);
            });
        }
    }
}
