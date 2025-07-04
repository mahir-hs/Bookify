using Bookify.Application.Abstractions.Messaging;
using Bookify.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace Bookify.Application.Abstractions.Behaviors;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseRequest
    where TResponse : Result
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var name = request.GetType().Name;

        try
        {
            _logger.LogInformation("Executing request {request}", name);

            var response = await next();

            if(response.IsSuccess)
                _logger.LogInformation("request {request} executed successfully", name);
            else
            {
                using(LogContext.PushProperty("errors", response.Error, true))
                {
                    _logger.LogWarning("request {request} failed with errors", name);
                }
            }
            return response;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while handling {request}", name);
            throw;
        }

    }
}