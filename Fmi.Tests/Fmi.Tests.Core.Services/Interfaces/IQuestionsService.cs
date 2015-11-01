using System.Collections.Generic;
using System.Threading.Tasks;
using Fmi.Tests.Contracts.Dto;

namespace Fmi.Tests.Core.Services.Interfaces
{
    public interface IQuestionsService
    {
        Task<IEnumerable<QuestionDto>> Get(int skip, int take);
        Task<QuestionDto> Get(int id);
        Task Create(QuestionDto question);
        Task Update(QuestionDto question);
        Task Delete(int id);
        Task<bool> IsCorrect(int id, int answer);
        Task<Dictionary<int, bool>> AreCorrect(Dictionary<int, int> questionAnswers);
    }
}
