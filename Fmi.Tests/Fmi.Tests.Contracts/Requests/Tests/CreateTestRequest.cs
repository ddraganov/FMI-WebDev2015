using Fmi.Tests.Contracts.Dto;

namespace Fmi.Tests.Contracts.Requests.Tests
{
    public class CreateTestRequest : IRequest
    {
        public BasicTestDto Test { get; set; }
    }
}
