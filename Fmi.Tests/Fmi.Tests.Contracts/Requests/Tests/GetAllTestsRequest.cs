using System.Collections.Generic;
using Fmi.Tests.Contracts.Dto;

namespace Fmi.Tests.Contracts.Requests.Tests
{
    public class GetAllTestsRequest : IRequest<IEnumerable<BasicTestDto>>
    { }
}
