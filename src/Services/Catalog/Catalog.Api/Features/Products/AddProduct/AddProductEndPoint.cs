namespace Catalog.API.Features.Products.AddProduct
{
    public class AddProductEndPoint : IEndPoint
    {
        public void MapEndPoint(IEndpointRouteBuilder builder)
        {
            builder.MapPost("/product/create-product", async (AddProductCommand command, ISender sender) =>
            {
                Results.Ok(await sender.Send(command));
            });
        }
    }
}
