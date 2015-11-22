using System.Threading.Tasks;
using AutoMapper;
using Fmi.Tests.Contracts.Requests.Questions;
using Fmi.Tests.Core.Handlers.Exceptions;
using Fmi.Tests.Core.Sql;

namespace Fmi.Tests.Core.Handlers.Features.Questions
{
    public class UpdateQuestionHandler : CommandHandler<UpdateQuestionRequest>
    {
        private readonly TestsContext _db;

        public UpdateQuestionHandler(TestsContext db)
        {
            _db = db;
        }

        protected override async Task HandleCore(UpdateQuestionRequest command)
        {
            var question = await _db.Questions.FindAsync(command.Question.Id).ConfigureAwait(false);

            if (question == null)
                throw new NotFoundException();

            Mapper.Map(command.Question, question);

            await _db.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
