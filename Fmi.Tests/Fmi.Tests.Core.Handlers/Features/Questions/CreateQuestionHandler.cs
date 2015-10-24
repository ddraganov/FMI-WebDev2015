using System.Threading.Tasks;
using Fmi.Tests.Contracts.Requests.Questions;

namespace Fmi.Tests.Core.Handlers.Features.Questions
{
    public class CreateQuestionHandler : CommandHandler<CreateQuestionRequest>
    {
        protected override async Task HandleCore(CreateQuestionRequest command)
        {
            //
        }
    }
}
