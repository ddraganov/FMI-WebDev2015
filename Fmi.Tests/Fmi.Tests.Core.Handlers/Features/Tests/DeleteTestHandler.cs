using System.Threading.Tasks;
using Fmi.Tests.Contracts.Requests.Tests;

namespace Fmi.Tests.Core.Handlers.Features.Tests
{
    public class DeleteTestHandler : CommandHandler<DeleteTestRequest>
    {
        protected override async Task HandleCore(DeleteTestRequest command)
        {
            //
        }
    }
}
