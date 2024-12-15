using BuildingBlocks.Result;
using Catalog.API.Domain.CategoryAggregate.DTOs;
using Catalog.API.Domain.ProductAggregate.Models;

namespace Catalog.API.Domain.CategoryAggregate.Models
{
    public class Category : BaseEntity<long>, ICreation, IModification
    {
        public string NameEn { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public List<Product>? Products { get; private set; }
        public Creation Creation { get; private set; } = null!;
        public Modification Modification { get; private set; } = null!;
        private Category()
        {
        }

        public static Result<Category> Create(CreateCategoryDto createCategoryDto)
        {
            Result validationResult = ValidateCreateCategory(createCategoryDto);
            if (!validationResult.IsSuccess)
            {
                return Result<Category>.Failure(validationResult.CombineErrors());
            }
            Category category = new Category()
            {
                NameEn = createCategoryDto.NameEn,
                Description = createCategoryDto.Description,
                Creation = new(createCategoryDto.CreatedBy),
                Modification = new(createCategoryDto.CreatedBy)
            };
            return Result<Category>.Success(category);
        }

        #region Input Validation
        private static Result ValidateCreateCategory(CreateCategoryDto createProductDto)
        {
            var validationResult = Result.Success();

            Result nameEnValidation = ValidateNameEn(createProductDto.NameEn);
            Result descriptionValidation = ValidateDescription(createProductDto.Description);

            validationResult.Combine(nameEnValidation, descriptionValidation);

            return validationResult;

        }
        #endregion

        #region Property Validation
        private static Result ValidateNameEn(string nameEn)
        {
            if (string.IsNullOrWhiteSpace(nameEn))
            {
                return Result.Failure(Messages.EmptyCategoryNameEn);
            }
            else if (nameEn.Length == 0)
            {
                return Result.Failure(Messages.InvalidCategoryNameEnLength);
            }
            return Result.Success();
        }
        private static Result ValidateDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                return Result.Failure(Messages.EmptyCategoryDescription);
            }
            else if (description.Length == 0)
            {
                return Result.Failure(Messages.InvalidCategoryDescriptionLength);
            }
            return Result.Success();
        }
        #endregion
    }
}
