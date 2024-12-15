using Catalog.API.Common.Validations.Abstractions;
using FluentValidation;

namespace Catalog.API.Common.Validations.Services
{
    public class ValidatorFactoryService : IValidatorFactoryService
    {
        private readonly IServiceProvider _serviceProvider;

        public ValidatorFactoryService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IValidator<T> GetValidator<T>()
        {
            return _serviceProvider.GetService<IValidator<T>>()!;
        }
    }
}
