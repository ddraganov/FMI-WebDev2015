using System.Collections.Generic;
using System.Threading.Tasks;
using Fmi.Tests.Contracts.Dto;

namespace Fmi.Tests.Core.Services.Interfaces
{
    public interface ITestsService
    {
        Task<IEnumerable<BasicTestDto>> Get();
        Task<FullTestDto> Get(string code);
        Task Create(BasicTestDto question);
        Task Update(BasicTestDto question);
        Task Delete(string code);
        Task AddQuestions(string code, List<int> questionIdList);
        Task AddQuestions(string code, List<CreateQuestionDto> questionIdList);
    }
}
