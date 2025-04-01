using FluentValidation;

namespace Catalog.API.Features.Products.DeleteProduct
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Empty Request Id")
                .NotNull()
                .WithMessage("Invalid Request Id");
        }
    }
}
