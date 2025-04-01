using BuildingBlocks.CQRS;
using FluentValidation;
using MediatR;

namespace BuildingBlocks.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommand<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResult = await Task.WhenAll(_validators.Select(x => x.ValidateAsync(context, cancellationToken)));
                
                var failuers = validationResult
                    .Where(x => x.Errors.Any())
                    .SelectMany(x => x.Errors.Select(x=>x.ErrorMessage))
                    .ToList();

                if (failuers.Any())
                {
                    throw new Exceptions.CustomExceptions.ValidationException(failuers);
                }
            }
            return await next();
        }
    }
}
