using MediatR;

namespace BuildingBlocks.CQRS
{
    public interface IQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IQuery<TResponse>
        where TResponse : notnull
    {
    }
    public interface IQueryHandler<TRequest> : IQueryHandler<TRequest, Unit>
    where TRequest : IQuery<Unit>
    {
    }
}
