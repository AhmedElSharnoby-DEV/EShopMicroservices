using FluentValidation;

namespace Catalog.API.Features.Products.GetProductByCategory
{
    public class GetProductsByCategoryQueryValidator : AbstractValidator<GetProductsByCategoryQuery>
    {
        public GetProductsByCategoryQueryValidator()
        {
            RuleFor(x => x.Category)
                .NotNull()
                .WithMessage("Empty Category")
                .NotEmpty()
                .WithMessage("Invalid Category");
        }
    }
}
