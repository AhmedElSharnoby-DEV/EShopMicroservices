using Carter;
using MediatR;

namespace Catalog.API.Features.Products.GetProducts
{
    public class GetProductsEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async ([AsParameters]GetProductsQuery query, ISender sender) =>
            {
                return await sender.Send(query);

            });
        }
    }
}
