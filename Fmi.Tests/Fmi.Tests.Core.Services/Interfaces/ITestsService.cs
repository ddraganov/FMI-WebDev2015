using System.Collections.Generic;
using System.Threading.Tasks;
using Fmi.Tests.Contracts.Dto;

namespace Fmi.Tests.Core.Services.Interfaces
{
    public interface ITestsService
    {
        Task<IEnumerable<TestDto>> Get(int skip, int take);
        Task<TestDto> Get(string code);
        Task Create(TestDto question);
        Task Update(TestDto question, string authToken);
        Task Delete(string id, string authToken);
        Task AddQuestions(string code, List<int> questionIdList, string authToken);
        Task AddQuestions(string code, List<QuestionDto> questionIdList);
    }
}
