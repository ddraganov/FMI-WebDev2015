using System.Threading.Tasks;
using AutoMapper;
using Fmi.Tests.Contracts.Dto;
using Fmi.Tests.Contracts.Requests.Questions;
using Fmi.Tests.Core.Handlers.Exceptions;
using Fmi.Tests.Core.Handlers.Interfaces;
using Fmi.Tests.Core.Sql;

namespace Fmi.Tests.Core.Handlers.Features.Questions
{
    public class GetQuestionHandler : IRequestHandler<GetQuestionRequest, QuestionDto>
    {
        private readonly TestsContext _db;

        public GetQuestionHandler(TestsContext db)
        {
            _db = db;
        }

        public async Task<QuestionDto> HandleAsync(GetQuestionRequest request)
        {
            var question = await _db.Questions.FindAsync(request.Id).ConfigureAwait(false);

            if (question == null)
                throw new NotFoundException();

            return Mapper.Map<QuestionDto>(question);
        }
    }
}
