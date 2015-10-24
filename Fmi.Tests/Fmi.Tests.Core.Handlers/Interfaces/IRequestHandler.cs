using System.Threading.Tasks;

namespace Fmi.Tests.Core.Handlers.Interfaces
{
    public interface IRequestHandler<in TRequest, TResponse>
        where TRequest : Contracts.IRequest<TResponse>, new()
    {
        /// <summary>
        /// Handles an asynchronous request
        /// </summary>
        /// <param name="request">The request message</param>
        /// <returns>A task representing the response from the request</returns>
        Task<TResponse> HandleAsync(TRequest request);
    }
}
