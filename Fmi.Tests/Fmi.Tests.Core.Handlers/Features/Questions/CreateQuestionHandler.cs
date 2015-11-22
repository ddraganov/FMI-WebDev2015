using System.Threading.Tasks;
using AutoMapper;
using Fmi.Tests.Contracts.Requests.Questions;
using Fmi.Tests.Core.Sql;
using Fmi.Tests.Core.Sql.Entities;

namespace Fmi.Tests.Core.Handlers.Features.Questions
{
    public class CreateQuestionHandler : CommandHandler<CreateQuestionRequest>
    {
        private readonly TestsContext _db;

        public CreateQuestionHandler(TestsContext db)
        {
            _db = db;
        }

        protected override async Task HandleCore(CreateQuestionRequest command)
        {
            var entity = Mapper.Map<QuestionEntity>(command.Question);
            _db.Questions.Add(entity);
            await _db.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
