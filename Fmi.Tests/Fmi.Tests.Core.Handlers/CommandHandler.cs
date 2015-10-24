using System.Threading.Tasks;
using Fmi.Tests.Contracts;
using Fmi.Tests.Core.Handlers.Interfaces;

namespace Fmi.Tests.Core.Handlers
{
    /// <summary>
    /// Helper class for requests that return a void response
    /// </summary>
    /// <typeparam name="TRequest">The type of void request being handled</typeparam>
    public abstract class CommandHandler<TRequest> : IRequestHandler<TRequest, Unit>
        where TRequest : IRequest, new()
    {
        /// <summary>
        /// Handles a void request
        /// </summary>
        /// <param name="command">The request message</param>
        protected abstract Task HandleCore(TRequest command);

        /// <summary>
        /// Handles a void request. Override to apply interception attributes.
        /// </summary>
        /// <param name="request">The request message</param>
        public virtual async Task<Unit> HandleAsync(TRequest request)
        {
            await HandleCore(request);

            return Unit.Value;
        }
    }
}
