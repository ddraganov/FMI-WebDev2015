using System.Threading.Tasks;
using Fmi.Tests.Contracts.Requests.Questions;
using Fmi.Tests.Core.Handlers.Exceptions;
using Fmi.Tests.Core.Sql;

namespace Fmi.Tests.Core.Handlers.Features.Questions
{
    public class DeleteQuestionHandler : CommandHandler<DeleteQuestionRequest>
    {
        private readonly TestsContext _db;

        public DeleteQuestionHandler(TestsContext db)
        {
            _db = db;
        }

        protected override async Task HandleCore(DeleteQuestionRequest command)
        {
            var question = await _db.Questions.FindAsync(command.Id).ConfigureAwait(false);

            if (question == null)
                throw new NotFoundException();

            _db.Answers.RemoveRange(question.Answers);
            _db.Questions.Remove(question);

            await _db.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
