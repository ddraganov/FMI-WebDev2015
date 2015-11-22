using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Fmi.Tests.Contracts.Dto;
using Fmi.Tests.Contracts.Requests.Questions;
using Fmi.Tests.Core.Handlers.Interfaces;
using Fmi.Tests.Core.Sql;

namespace Fmi.Tests.Core.Handlers.Features.Questions
{
    public class GetAllQuestionsHandler : IRequestHandler<GetAllQuestionsRequest, IEnumerable<QuestionDto>>
    {
        private readonly TestsContext _db;

        public GetAllQuestionsHandler(TestsContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<QuestionDto>> HandleAsync(GetAllQuestionsRequest request)
        {
            return (await _db.Questions
                .OrderBy(e => e.Id)
                .Skip(request.Skip)
                .Take(request.Take)
                .ToListAsync()
                .ConfigureAwait(false)).Select(Mapper.Map<QuestionDto>);
        }
    }
}
