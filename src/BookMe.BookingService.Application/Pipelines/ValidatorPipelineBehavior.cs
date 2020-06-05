using System;
using System.Threading;
using System.Threading.Tasks;
using BookMe.BookingService.Application.Commands.Abstractions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BookMe.BookingService.Application.Pipelines
{
    public class ValidatorPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly string _commandType = typeof(TRequest).Name;
        private readonly ILogger<ValidatorPipelineBehavior<TRequest, TResponse>> _logger;

        public ValidatorPipelineBehavior(ILogger<ValidatorPipelineBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public Task<TResponse> Handle(TRequest command, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (command is IValidatabe)
            {
                var validatableCommand = command as IValidatabe;

                try
                {
                    validatableCommand.Validate();

                    _logger.LogInformation("[MediatR] Command: {commandType} was successfully validated", _commandType);
                }
                catch(Exception ex)
                {
                    _logger.LogError(ex, "[MediatR] Validation of command: {commandType} failed", _commandType);
                    throw;
                }
            }
            else
            {
                _logger.LogInformation("[MediatR] Validation of command: {commandType} was skipped", _commandType);
            }

            return next();
        }
    }
}
