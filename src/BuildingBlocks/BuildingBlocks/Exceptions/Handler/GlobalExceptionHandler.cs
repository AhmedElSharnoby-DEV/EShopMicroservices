using BuildingBlocks.Exceptions.CustomExceptions;
using BuildingBlocks.Responses;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace BuildingBlocks.Exceptions.Handler
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError($"Start:: Error: {exception.Message} has occured, Error Source: {exception.Source}");
            if(exception is BadRequestException || exception is NotFoundException)
            {
                var response = Response<GlobalExceptionHandler>.Fail(exception.Message);
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
            else if(exception is ValidationException validationException)
            {
                var response = Response<GlobalExceptionHandler>.Fail(validationException._failures);
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
            else
            {
                var response = Response<GlobalExceptionHandler>.Fail(exception.Message);
                httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
            _logger.LogInformation("End:: Log error");
            return true;
        }
    }
}
