using System.Diagnostics;
using System.Threading.Tasks;
using Autofac;
using Fmi.Tests.Contracts;
using Fmi.Tests.Core.Handlers.Interfaces;

namespace Fmi.Tests.Core.Handlers
{
    public class Mediator : IMediator
    {
        private readonly ILifetimeScope _scope;

        public Mediator(ILifetimeScope scope)
        {
            _scope = scope;
        }

        [DebuggerStepThrough]
        public Task<TResponse> ExecuteAsync<TResponse>(IRequest<TResponse> request)
        {
            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));

            dynamic handler = _scope.Resolve(handlerType);

            return handler.HandleAsync((dynamic)request);
        }
    }
}
