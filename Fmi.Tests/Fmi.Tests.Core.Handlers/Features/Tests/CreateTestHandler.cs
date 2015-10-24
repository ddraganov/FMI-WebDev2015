using System.Threading.Tasks;
using Fmi.Tests.Contracts.Requests.Tests;

namespace Fmi.Tests.Core.Handlers.Features.Tests
{
    public class CreateTestHandler : CommandHandler<CreateTestRequest>
    {
        protected override async Task HandleCore(CreateTestRequest command)
        {
            //
        }
    }
}
