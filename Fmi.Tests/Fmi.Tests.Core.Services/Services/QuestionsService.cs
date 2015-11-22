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
    public class QuestionsService : IQuestionsService
    {
        private readonly TestsContext _db;

        public QuestionsService(TestsContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<QuestionDto>> Get(int skip, int take)
        {
            return (await _db.Questions
                .OrderBy(e => e.Id)
                .Skip(skip)
                .Take(take)
                .ToListAsync()
                .ConfigureAwait(false)).Select(Mapper.Map<QuestionDto>);
        }

        public async Task<QuestionDto> Get(int id)
        {
            var question = await _db.Questions.FindAsync(id).ConfigureAwait(false);

            if (question == null)
                throw new NotFoundException();

            return Mapper.Map<QuestionDto>(question);
        }

        public async Task Create(QuestionDto question)
        {
            var entity = Mapper.Map<QuestionEntity>(question);
            _db.Questions.Add(entity);
            await _db.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Update(QuestionDto questionDto)
        {
            var question = await _db.Questions.FindAsync(questionDto.Id).ConfigureAwait(false);

            if (question == null)
                throw new NotFoundException();

            Mapper.Map(questionDto, question);

            await _db.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task Delete(int id)
        {
            var question = await _db.Questions.FindAsync(id).ConfigureAwait(false);

            if (question == null)
                throw new NotFoundException();

            _db.Answers.RemoveRange(question.Answers);
            _db.Questions.Remove(question);

            await _db.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<bool> IsCorrect(int id, int answer)
        {
            var question = await _db.Questions.FindAsync(id).ConfigureAwait(false);

            if (question == null)
                throw new NotFoundException();

            return question.Answers.Any(a => a.Id == answer && a.IsCorrect);
        }

        public async Task<Dictionary<int, bool>> AreCorrect(Dictionary<int, int> questionAnswers)
        {
            var result = new Dictionary<int, bool>();

            foreach (var questionAnswer in questionAnswers)
            {
                var question = await _db.Questions.FindAsync(questionAnswer.Key).ConfigureAwait(false);

                if (question == null)
                    throw new NotFoundException();

                result[question.Id] = question.Answers.Any(a => a.Id == questionAnswer.Value && a.IsCorrect);
            }

            return result;
        }
    }
}
