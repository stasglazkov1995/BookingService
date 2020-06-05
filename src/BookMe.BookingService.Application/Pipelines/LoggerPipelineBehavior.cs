using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MediatR;

namespace BookMe.BookingService.Application.Pipelines
{
    public class LoggerPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly string _commandType = typeof(TRequest).Name;
        private readonly ILogger<LoggerPipelineBehavior<TRequest, TResponse>> _logger;

        public LoggerPipelineBehavior(ILogger<LoggerPipelineBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest command, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation("[MedaitR] Started processing command: {commandType}", _commandType);

            try
            {
                return await next();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "[MediatR] Error during processiong command: {commandType}", _commandType);
                throw;
            }
            finally
            {
                _logger.LogInformation("[MedaitR] Finished processing command: {commandType}", _commandType);
            }
        }
    }
}
