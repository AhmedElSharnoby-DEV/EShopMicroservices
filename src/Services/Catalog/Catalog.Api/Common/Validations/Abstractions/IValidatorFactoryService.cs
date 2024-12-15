using FluentValidation;

namespace Catalog.API.Common.Validations.Abstractions
{
    public interface IValidatorFactoryService
    {
        IValidator<T> GetValidator<T>();
    }
}
