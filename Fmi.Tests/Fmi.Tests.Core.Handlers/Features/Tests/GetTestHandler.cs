using System.Threading.Tasks;
using AutoMapper;
using Fmi.Tests.Contracts.Dto;
using Fmi.Tests.Contracts.Requests.Tests;
using Fmi.Tests.Core.Handlers.Exceptions;
using Fmi.Tests.Core.Handlers.Interfaces;
using Fmi.Tests.Core.Sql;

namespace Fmi.Tests.Core.Handlers.Features.Tests
{
    public class GetTestHandler : IRequestHandler<GetTestRequest, TestDto>
    {
        private readonly TestsContext _db;

        public GetTestHandler(TestsContext db)
        {
            _db = db;
        }

        public async Task<TestDto> HandleAsync(GetTestRequest request)
        {
            var test = await _db.Tests.FindAsync(request.Id).ConfigureAwait(false);

            if (test == null)
                throw new NotFoundException();

            return Mapper.Map<TestDto>(test);
        }
    }
}
