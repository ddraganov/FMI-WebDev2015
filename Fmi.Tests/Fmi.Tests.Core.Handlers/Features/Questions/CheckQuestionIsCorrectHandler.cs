using System.Threading.Tasks;
using Fmi.Tests.Contracts.Requests.Questions;
using Fmi.Tests.Core.Handlers.Interfaces;

namespace Fmi.Tests.Core.Handlers.Features.Questions
{
    public class CheckQuestionIsCorrectHandler : IRequestHandler<CheckQuestionIsCorrectRequest, bool>
    {
        public async Task<bool> HandleAsync(CheckQuestionIsCorrectRequest request)
        {
            return true;
        }
    }
}
