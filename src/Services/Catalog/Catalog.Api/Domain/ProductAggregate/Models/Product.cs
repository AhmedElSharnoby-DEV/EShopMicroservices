using BuildingBlocks.Resources;
using BuildingBlocks.Result;
using Catalog.API.Domain.CategoryAggregate.Models;
using Catalog.API.Domain.ProductAggregate.DTOs;

namespace Catalog.API.Domain.ProductAggregate.Models
{
    public class Product : BaseEntity<long>, ICreation, IModification
    {
        public string NameEn { get; private set; } = null!;
        public string NameAr { get; private set; } = null!;
        public string Description { get; private set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public DateTime ProductionDate { get; private set; }
        public DateTime ExpiryDate { get; private set; }
        public List<Category> Categories { get; private set; }
        public Creation Creation { get; private set; } = null!;
        public Modification Modification { get; private set; } = null!;
        private Product()
        {
            Categories = new();
        }
        public static Result<Product> Create(CreateProductDto createProductDto)
        {
            Result validatioResult = ValidateCreateProduct(createProductDto);

            if (!validatioResult.IsSuccess)
            {
                return Result<Product>.Failure(validatioResult.CombineErrors());
            }

            Product product = new Product()
            {
                NameEn = createProductDto.NameEn,
                NameAr = createProductDto.NameAr,
                Description = createProductDto.Description,
                ImageUrl = createProductDto.ImageUrl,
                ProductionDate = createProductDto.ProductionDate,
                ExpiryDate = createProductDto.ExpiryDate,
                Categories = createProductDto.Categories,
                Creation = new("Test_User"),
                Modification = new("Test_User")
            };

            return Result<Product>.Success(product);
        }

        public Result<Product> Update(UpdateProductDto createProductDto)
        {
            Result validatioResult = ValidateUpdateProduct(createProductDto);

            if (!validatioResult.IsSuccess)
            {
                return Result<Product>.Failure(validatioResult.CombineErrors());
            }

            NameEn = createProductDto.NameEn;
            NameAr = createProductDto.NameAr;
            Description = createProductDto.Description;
            ImageUrl = createProductDto.ImageUrl;
            ProductionDate = createProductDto.ProductionDate;
            ExpiryDate = createProductDto.ExpiryDate;
            Categories = createProductDto.Categories;
            Modification = new("Test_User");

            return Result<Product>.Success(this);
        }

        #region Input Validation
        private static Result ValidateCreateProduct(CreateProductDto createProductDto)
        {
            var validationResult = Result.Success();

            Result nameEnValidation = ValidateNameEn(createProductDto.NameEn);
            Result nameArValidation = ValidateNameAr(createProductDto.NameAr);
            Result descriptionValidation = ValidateDescription(createProductDto.Description);
            Result imageUrlValidation = ValidateImageUrl(createProductDto.ImageUrl);
            Result productionDateValidation = ValidateProductionDate(createProductDto.ProductionDate);
            Result expiryDateValidation = ValidateExpiryDate(createProductDto.ExpiryDate);

            validationResult.Combine(nameEnValidation, nameArValidation,
                descriptionValidation, imageUrlValidation,
                productionDateValidation, expiryDateValidation);

            return validationResult;

        }
        private static Result ValidateUpdateProduct(UpdateProductDto createProductDto)
        {
            var validationResult = Result.Success();

            Result nameEnValidation = ValidateNameEn(createProductDto.NameEn);
            Result nameArValidation = ValidateNameAr(createProductDto.NameAr);
            Result descriptionValidation = ValidateDescription(createProductDto.Description);
            Result imageUrlValidation = ValidateImageUrl(createProductDto.ImageUrl);
            Result productionDateValidation = ValidateProductionDate(createProductDto.ProductionDate);
            Result expiryDateValidation = ValidateExpiryDate(createProductDto.ExpiryDate);

            validationResult.Combine(nameEnValidation, nameArValidation,
                descriptionValidation, imageUrlValidation,
                productionDateValidation, expiryDateValidation);

            return validationResult;

        }
        #endregion

        #region Property Validation
        private static Result ValidateNameEn(string nameEn)
        {
            if(string.IsNullOrWhiteSpace(nameEn))
            {
                return Result.Failure(Messages.EmptyProductNameEn);
            }
            else if(nameEn.Length == 0)
            {
                return Result.Failure(Messages.InvalidProductNameEnLength);
            }
            return Result.Success();
        }
        private static Result ValidateNameAr(string nameAr)
        {
            if (string.IsNullOrWhiteSpace(nameAr))
            {
                return Result.Failure(Messages.EmptyProductNameAr);
            }
            else if (nameAr.Length == 0)
            {
                return Result.Failure(Messages.InvalidProductNameArLength);
            }
            return Result.Success();
        }
        private static Result ValidateDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                return Result.Failure(Messages.EmptyProductDescription);
            }
            else if (description.Length == 0)
            {
                return Result.Failure(Messages.InvalidProductDescriptionLength);
            }
            return Result.Success();
        }
        private static Result ValidateImageUrl(string imageUrl)
        {
            if (string.IsNullOrWhiteSpace(imageUrl))
            {
                return Result.Failure(Messages.EmptyProductImageUrl);
            }
            else if (imageUrl.Length == 0)
            {
                return Result.Failure(Messages.InvalidProductImageUrlLength);
            }
            return Result.Success();
        }
        private static Result ValidateProductionDate(DateTime productionDate)
        {
            if (productionDate> DateTime.Now )
            {
                return Result.Failure(Messages.InvalidProductProductionDate);
            }
            return Result.Success();
        }
        private static Result ValidateExpiryDate(DateTime expiryDate)
        {
            if (expiryDate <= DateTime.Now)
            {
                return Result.Failure(Messages.InvalidProductExpiryDate);
            }
            return Result.Success();
        }
        private static Result ValidateCategories(List<Category> categories)
        {
            if (categories is null || categories.Any())
            {
                return Result.Failure(Messages.InvalidProductCategories);
            }
            return Result.Success();
        }
        #endregion
    }
}
