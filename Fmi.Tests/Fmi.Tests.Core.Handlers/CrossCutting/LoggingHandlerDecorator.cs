using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Fmi.Tests.Contracts;
using Fmi.Tests.Core.Handlers.Interfaces;

namespace Fmi.Tests.Core.Handlers.CrossCutting
{
    /// <summary>
    /// Such classes can be used to solce cross cutting concerns like logging, exception handling, validation, etc.
    /// For simplicity we will leave this empty for now
    /// </summary>
    public class LoggingHandlerDecorator<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : class, IRequest<TResponse>, new()
    {
        private readonly IRequestHandler<TRequest, TResponse> _decorated;

        public LoggingHandlerDecorator(IRequestHandler<TRequest, TResponse> decorated)
        {
            _decorated = decorated;
        }

        [DebuggerStepThrough]
        public async Task<TResponse> HandleAsync(TRequest request)
        {
            TResponse response;

            try
            {
                response = await _decorated.HandleAsync(request);
            }
            catch (Exception)
            {
                throw;
            }

            return response;
        }
    }
}
