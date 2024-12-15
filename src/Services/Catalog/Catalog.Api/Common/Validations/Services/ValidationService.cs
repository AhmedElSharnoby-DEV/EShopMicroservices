using BuildingBlocks.Responses;
using Catalog.API.Common.Validations.Abstractions;

namespace Catalog.API.Common.Validations.Services
{
    public class ValidationService : IValidationService
    {
        private readonly IValidatorFactoryService _validatorFactory;

        public ValidationService(IValidatorFactoryService validatorFactory)
        {
            _validatorFactory = validatorFactory;
        }
        public async Task<Response> ValidateAsync<TCommand>(TCommand command)
        {
            var validator = _validatorFactory.GetValidator<TCommand>();

            if (validator is null)
            {
                return new Response
                {
                    IsSuccess = true,
                    Errors = null
                };
            }

            var validationResult = await validator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return new Response
                {
                    IsSuccess = false,
                    Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToArray()
                };
            }

            return new Response
            {
                IsSuccess = true,
                Errors = null
            };
        }

    }
}
