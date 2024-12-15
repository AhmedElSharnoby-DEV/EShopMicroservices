using Catalog.API.Domain.ProductAggregate.DTOs;
using Catalog.API.Domain.ProductAggregate.Models;

namespace Catalog.API.Features.Products.AddProduct
{
    public class AddProductCommandHandler : ICommandHandler<AddProductCommand, Response<ProductResponseDto>>
    {
        private readonly IValidationService _validationService;

        public AddProductCommandHandler(IValidationService validationService)
        {
            _validationService = validationService;
        }
        public async Task<Response<ProductResponseDto>> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            // validation
            var validationResult = await _validationService.ValidateAsync(request);
            if (!validationResult.IsSuccess)
            {
                throw new BadRequestException(string.Concat(validationResult.Errors, ", "));
            }
            // get categories and validate

            // create product

            var product = Product.Create(new CreateProductDto()
            {
                NameEn = request.NameEn,
                NameAr = request.NameAr,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                ProductionDate = request.ProductionDate,
                ExpiryDate = request.ExpiryDate
                //createdBy = request.CreatedBy
            });


            // return product code
            return new Response<ProductResponseDto>()
        }
    }
}
