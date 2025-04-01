using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BuildingBlocks.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull , IRequest<TResponse>
        where TResponse : notnull
    {
        private readonly ILogger _logger;
        public LoggingBehavior(ILogger logger)
        {
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"[Start] Excute Request From Type {typeof(TRequest).Name}" +
                $" , With Response From Type {typeof(TResponse).Name}");

            var timer = new Stopwatch();
            timer.Start();

            var response = await next();

            timer.Stop();

            _logger.LogInformation($"[End] Excute Request From Type {typeof(TRequest).Name}" +
                $" , With Response From Type {typeof(TResponse).Name}" +
                $", Time Consumed {timer.ElapsedMilliseconds}");

            return response;
        }
    }
}
