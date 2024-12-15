namespace Catalog.API.Features.Products.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage(Messages.InvalidProductId)
                .Must(x => x > 0)
                .WithMessage(Messages.InvalidProductId);

            RuleFor(x => x.NameEn)
                .NotEmpty()
                .WithMessage(Messages.EmptyProductNameEn);

            RuleFor(x => x.NameAr)
                .NotEmpty()
                .WithMessage(Messages.EmptyProductNameAr);

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage(Messages.EmptyProductDescription);

            RuleFor(x => x.ImageUrl)
                .NotEmpty()
                .WithMessage(Messages.EmptyProductImageUrl);

            RuleFor(x => x.ProductionDate)
                .NotNull()
                .WithMessage(Messages.InvalidProductProductionDate)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage(Messages.InvalidProductProductionDate);

            RuleFor(x => x.ExpiryDate)
                .NotNull()
                .WithMessage(Messages.InvalidProductExpiryDate)
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage(Messages.InvalidProductExpiryDate);

            RuleForEach(x => x.Categories)
                .Must(x => x > 0)
                .WithMessage(Messages.InvalidProductCategories);

            RuleFor(x => x.Categories)
                .Must(Helper.HaveUniqueValues)
                .WithMessage(Messages.DuplicateProductCategories);
        }

    }
}
