using System.Threading.Tasks;
using Fmi.Tests.Contracts;

namespace Fmi.Tests.Core.Handlers.Interfaces
{
    public interface IMediator
    {
        Task<TResponse> ExecuteAsync<TResponse>(IRequest<TResponse> request);
    }
}
