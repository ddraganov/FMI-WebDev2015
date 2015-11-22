using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Fmi.Tests.Contracts.Dto;
using Fmi.Tests.Core.Services.Exceptions;
using Fmi.Tests.Core.Services.Interfaces;
using Fmi.Tests.Core.Sql;
using Fmi.Tests.Core.Sql.Entities;

namespace Fmi.Tests.Core.Services.Services
{
    public class TestsService : ITestsService
    {
        private readonly TestsContext _db;

        public TestsService(TestsContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<TestDto>> Get(int skip, int take)
        {
            return (await _db.Tests
                .OrderBy(e => e.Code)
                .Skip(skip)
                .Take(take)
                .ToListAsync()
                .ConfigureAwait(false)).Select(Mapper.Map<TestDto>);
        }

        public async Task<TestDto> Get(string code)
        {
            var test = await _db.Tests.FindAsync(code).ConfigureAwait(false);

            if (test == null)
                throw new NotFoundException();

            return Mapper.Map<TestDto>(test);
        }

        public async Task Create(TestDto test)
        {
            var entity = Mapper.Map<TestEntity>(test);
            _db.Tests.Add(entity);
            await _db.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Update(TestDto testDto)
        {
            var test = await _db.Tests.FindAsync(testDto.Code).ConfigureAwait(false);

            if (test == null)
                throw new NotFoundException();

            Mapper.Map(testDto, test);

            await _db.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Delete(string id)
        {
            var test = await _db.Tests.FindAsync(id).ConfigureAwait(false);

            if (test == null)
                throw new NotFoundException();

            _db.Tests.Remove(test);

            await _db.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task AddQuestions(string code, List<int> questionIdList)
        {
            var test = await _db.Tests.FindAsync(code).ConfigureAwait(false);

            if (test == null)
                throw new NotFoundException();

            var questions = await _db.Questions.Where(e => questionIdList.Contains(e.Id))
                .ToListAsync().ConfigureAwait(false);

            questions.ForEach(q => test.Questions.Add(q));

            await _db.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
