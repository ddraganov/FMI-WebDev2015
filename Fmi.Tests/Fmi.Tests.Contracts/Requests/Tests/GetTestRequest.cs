using Fmi.Tests.Contracts.Dto;

namespace Fmi.Tests.Contracts.Requests.Tests
{
    public class GetTestRequest : IRequest<TestDto>
    {
        public string Id { get; set; }
    }
}
