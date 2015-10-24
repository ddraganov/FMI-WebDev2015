using System.Threading.Tasks;
using Fmi.Tests.Contracts.Requests.Questions;

namespace Fmi.Tests.Core.Handlers.Features.Questions
{
    public class DeleteQuestionHandler : CommandHandler<DeleteQuestionRequest>
    {
        protected override async Task HandleCore(DeleteQuestionRequest command)
        {
            //
        }
    }
}
