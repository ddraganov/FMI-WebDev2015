using System.Collections.Generic;
using System.Threading.Tasks;
using Fmi.Tests.Contracts.Requests.Questions;
using Fmi.Tests.Core.Handlers.Interfaces;

namespace Fmi.Tests.Core.Handlers.Features.Questions
{
    public class CheckQuestionsAreCorrectHandler : IRequestHandler<CheckQuestionsAreCorrectRequest, Dictionary<int, bool>>
    {
        public async Task<Dictionary<int, bool>> HandleAsync(CheckQuestionsAreCorrectRequest request)
        {
            return new Dictionary<int, bool>
            {
                { 1, true },
                { 2, false }
            };
        }
    }
}
