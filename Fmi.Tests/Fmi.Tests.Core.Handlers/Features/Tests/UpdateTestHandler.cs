using System.Threading.Tasks;
using Fmi.Tests.Contracts.Requests.Tests;

namespace Fmi.Tests.Core.Handlers.Features.Tests
{
    public class UpdateTestHandler : CommandHandler<UpdateTestRequest>
    {
        protected override async Task HandleCore(UpdateTestRequest command)
        {
            //
        }
    }
}
