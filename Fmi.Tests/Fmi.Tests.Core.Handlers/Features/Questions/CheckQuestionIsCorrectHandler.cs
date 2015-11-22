using System.Linq;
using System.Threading.Tasks;
using Fmi.Tests.Contracts.Requests.Questions;
using Fmi.Tests.Core.Handlers.Exceptions;
using Fmi.Tests.Core.Handlers.Interfaces;
using Fmi.Tests.Core.Sql;

namespace Fmi.Tests.Core.Handlers.Features.Questions
{
    public class CheckQuestionIsCorrectHandler : IRequestHandler<CheckQuestionIsCorrectRequest, bool>
    {
        private readonly TestsContext _db;

        public CheckQuestionIsCorrectHandler(TestsContext db)
        {
            _db = db;
        }

        public async Task<bool> HandleAsync(CheckQuestionIsCorrectRequest request)
        {
            var question = await _db.Questions.FindAsync(request.Id).ConfigureAwait(false);

            if (question == null)
                throw new NotFoundException();

            return question.Answers.Any(a => a.Id == request.Answer && a.IsCorrect);
        }
    }
}
