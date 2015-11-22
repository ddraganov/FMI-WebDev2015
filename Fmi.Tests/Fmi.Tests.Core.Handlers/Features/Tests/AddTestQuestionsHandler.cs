using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Fmi.Tests.Contracts.Requests.Tests;
using Fmi.Tests.Core.Handlers.Exceptions;
using Fmi.Tests.Core.Sql;

namespace Fmi.Tests.Core.Handlers.Features.Tests
{
    public class AddTestQuestionsHandler : CommandHandler<AddTestQuestionsRequest>
    {
        private readonly TestsContext _db;

        public AddTestQuestionsHandler(TestsContext db)
        {
            _db = db;
        }

        protected override async Task HandleCore(AddTestQuestionsRequest command)
        {
            var test = await _db.Tests.FindAsync(command.TestCode).ConfigureAwait(false);

            if (test == null)
                throw new NotFoundException();

            var questions = await _db.Questions.Where(e => command.QuestionIdList.Contains(e.Id))
                .ToListAsync().ConfigureAwait(false);

            questions.ForEach(q => test.Questions.Add(q));

            await _db.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
