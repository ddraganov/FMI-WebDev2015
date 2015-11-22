using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fmi.Tests.Contracts.Requests.Questions;
using Fmi.Tests.Core.Handlers.Exceptions;
using Fmi.Tests.Core.Handlers.Interfaces;
using Fmi.Tests.Core.Sql;

namespace Fmi.Tests.Core.Handlers.Features.Questions
{
    public class CheckQuestionsAreCorrectHandler : IRequestHandler<CheckQuestionsAreCorrectRequest, Dictionary<int, bool>>
    {
        private readonly TestsContext _db;

        public CheckQuestionsAreCorrectHandler(TestsContext db)
        {
            _db = db;
        }

        public async Task<Dictionary<int, bool>> HandleAsync(CheckQuestionsAreCorrectRequest request)
        {
            var result = new Dictionary<int, bool>();

            foreach (var questionAnswer in request.QuestionAnswers)
            {
                var question = await _db.Questions.FindAsync(questionAnswer.Key).ConfigureAwait(false);

                if (question == null)
                    throw new NotFoundException();

                result[question.Id] = question.Answers.Any(a => a.Id == questionAnswer.Value && a.IsCorrect);
            }

            return result;
        }
    }
}
