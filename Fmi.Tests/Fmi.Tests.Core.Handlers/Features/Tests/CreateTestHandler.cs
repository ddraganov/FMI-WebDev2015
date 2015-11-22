using System.Threading.Tasks;
using AutoMapper;
using Fmi.Tests.Contracts.Requests.Tests;
using Fmi.Tests.Core.Sql;
using Fmi.Tests.Core.Sql.Entities;

namespace Fmi.Tests.Core.Handlers.Features.Tests
{
    public class CreateTestHandler : CommandHandler<CreateTestRequest>
    {
        private readonly TestsContext _db;

        public CreateTestHandler(TestsContext db)
        {
            _db = db;
        }

        protected override async Task HandleCore(CreateTestRequest command)
        {
            var entity = Mapper.Map<TestEntity>(command.Test);
            _db.Tests.Add(entity);
            await _db.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
