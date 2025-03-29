using Carter;
using MediatR;

namespace Catalog.API.Features.Products.DeleteProduct
{
    public class DeleteProductEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/delete-product", async (Guid id, ISender sender) =>
            {
                return await sender.Send(new DeleteProductCommand() { Id = id });
            });
        }
    }
}
