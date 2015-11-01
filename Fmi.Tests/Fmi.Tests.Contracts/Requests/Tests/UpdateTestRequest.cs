using Fmi.Tests.Contracts.Dto;

namespace Fmi.Tests.Contracts.Requests.Tests
{
    public class UpdateTestRequest : IRequest
    {
        public TestDto Test { get; set; }
        public string AuthToken { get; set; }
    }
}
