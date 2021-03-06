﻿using System.Threading.Tasks;
using AutoMapper;
using Fmi.Tests.Contracts.Requests.Tests;
using Fmi.Tests.Core.Handlers.Exceptions;
using Fmi.Tests.Core.Sql;

namespace Fmi.Tests.Core.Handlers.Features.Tests
{
    public class UpdateTestHandler : CommandHandler<UpdateTestRequest>
    {
        private readonly TestsContext _db;

        public UpdateTestHandler(TestsContext db)
        {
            _db = db;
        }

        protected override async Task HandleCore(UpdateTestRequest command)
        {
            var test = await _db.Tests.FindAsync(command.Test.Code).ConfigureAwait(false);

            if (test == null)
                throw new NotFoundException();

            Mapper.Map(command.Test, test);

            await _db.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
