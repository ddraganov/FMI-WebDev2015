using System.Collections.Generic;
using System.Threading.Tasks;
using Fmi.Tests.Contracts.Dto;

namespace Fmi.Tests.Core.Services.Interfaces
{
    public interface IQuestionsService
    {
        Task<IEnumerable<QuestionDto>> Get();
        Task<QuestionDto> Get(int id);
        Task Create(CreateQuestionDto question);
        Task Update(QuestionDto question);
        Task Delete(int id);
    }
}
