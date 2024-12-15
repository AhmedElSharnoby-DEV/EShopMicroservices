namespace Catalog.API.Features.Products.UpdateProduct
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, Response<ProductResponseDto>>
    {
        private readonly IValidationService _validationService;

        public UpdateProductCommandHandler(IValidationService validationService)
        {
            _validationService = validationService;
        }
        public async Task<Response<ProductResponseDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validationService.ValidateAsync(request);
            if (!validationResult.IsSuccess)
            {
                throw new BadRequestException(string.Concat(validationResult.Errors, ", "));
            }
            // get product

            // get categories and validate

            // update product
        }
    }
}
