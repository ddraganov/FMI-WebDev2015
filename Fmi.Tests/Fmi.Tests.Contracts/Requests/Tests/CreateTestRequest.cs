using Fmi.Tests.Contracts.Dto;

namespace Fmi.Tests.Contracts.Requests.Tests
{
    public class CreateTestRequest : IRequest
    {
        public TestDto Test { get; set; }
    }
}
