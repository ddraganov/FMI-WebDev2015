using System.Threading.Tasks;
using Fmi.Tests.Contracts.Requests.Tests;
using Fmi.Tests.Core.Handlers.Exceptions;
using Fmi.Tests.Core.Sql;

namespace Fmi.Tests.Core.Handlers.Features.Tests
{
    public class DeleteTestHandler : CommandHandler<DeleteTestRequest>
    {
        private readonly TestsContext _db;

        public DeleteTestHandler(TestsContext db)
        {
            _db = db;
        }

        protected override async Task HandleCore(DeleteTestRequest command)
        {
            var test = await _db.Tests.FindAsync(command.Id).ConfigureAwait(false);

            if (test == null)
                throw new NotFoundException();

            _db.Tests.Remove(test);

            await _db.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
