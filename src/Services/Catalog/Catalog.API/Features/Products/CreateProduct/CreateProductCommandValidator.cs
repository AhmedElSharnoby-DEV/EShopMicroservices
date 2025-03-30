using FluentValidation;

namespace Catalog.API.Features.Products.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Invalid Product Name");

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull()
                .WithMessage("Invalid Product Description");

            RuleFor(x => x.ImageUrl)
                .NotEmpty()
                .NotNull()
                .WithMessage("Invalid Product ImageUrl");

            RuleFor(x => x.Price)
                .Must(x => x > 0)
                .WithMessage("Invalid Product Price");

            RuleFor(x => x.Categories)
                .NotEmpty()
                .Must(x => x.Count > 0)
                .WithMessage("Invalid Empty Categories");

            RuleForEach(x => x.Categories)
                .Must(x => !string.IsNullOrWhiteSpace(x))
                .WithMessage("Invalid Categories");
                


        }
    }
}
