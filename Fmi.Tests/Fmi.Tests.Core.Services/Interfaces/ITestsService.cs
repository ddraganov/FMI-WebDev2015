using System.Collections.Generic;
using System.Threading.Tasks;
using Fmi.Tests.Contracts.Dto;

namespace Fmi.Tests.Core.Services.Interfaces
{
    public interface ITestsService
    {
        Task<IEnumerable<TestDto>> Get(int skip, int take);
        Task<TestDto> Get(string code);
        Task Create(TestDto test);
        Task Update(TestDto test);
        Task Delete(string id);
        Task AddQuestions(string code, List<int> questionIdList);
    }
}
