using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Fmi.Tests.Contracts.Dto;
using Fmi.Tests.Contracts.Requests.Tests;
using Fmi.Tests.Core.Handlers.Interfaces;
using Fmi.Tests.Core.Sql;

namespace Fmi.Tests.Core.Handlers.Features.Tests
{
    public class GetAllTestsHandler : IRequestHandler<GetAllTestsRequest, IEnumerable<TestDto>>
    {
        private readonly TestsContext _db;

        public GetAllTestsHandler(TestsContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<TestDto>> HandleAsync(GetAllTestsRequest request)
        {
            return (await _db.Tests
                .OrderBy(e => e.Code)
                .Skip(request.Skip)
                .Take(request.Take)
                .ToListAsync()
                .ConfigureAwait(false)).Select(Mapper.Map<TestDto>);
        }
    }
}
