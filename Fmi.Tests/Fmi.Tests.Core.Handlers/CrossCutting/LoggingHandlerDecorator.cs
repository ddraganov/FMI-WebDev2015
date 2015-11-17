using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Fmi.Tests.Contracts;
using Fmi.Tests.Core.Handlers.Interfaces;
using Newtonsoft.Json;

namespace Fmi.Tests.Core.Handlers.CrossCutting
{
    /// <summary>
    /// Such classes can be used to solve cross cutting concerns like logging, exception handling, validation, etc.
    /// </summary>
    public class LoggingHandlerDecorator<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : class, IRequest<TResponse>, new()
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IRequestHandler<TRequest, TResponse> _decorated;

        public LoggingHandlerDecorator(IRequestHandler<TRequest, TResponse> decorated)
        {
            _decorated = decorated;
        }

        [DebuggerStepThrough]
        public async Task<TResponse> HandleAsync(TRequest request)
        {
            TResponse response;

            Log.Info("Executing request: " + JsonConvert.SerializeObject(request));

            try
            {
                response = await _decorated.HandleAsync(request);
            }
            catch (Exception e)
            {
                Log.Error("Exception: " + e.Message);
                throw;
            }

            Log.Info("Returning response: " + JsonConvert.SerializeObject(response));

            return response;
        }
    }
}
