using BuildingBlocks.Responses;
namespace Catalog.API.Common.Validations.Abstractions
{
    public interface IValidationService
    {
        Task<Response> ValidateAsync<TCommand>(TCommand command);
    }
}
