using System.Threading.Tasks;
using Fmi.Tests.Contracts.Requests.Questions;

namespace Fmi.Tests.Core.Handlers.Features.Questions
{
    public class UpdateQuestionHandler : CommandHandler<UpdateQuestionRequest>
    {
        protected override async Task HandleCore(UpdateQuestionRequest command)
        {
            //
        }
    }
}
