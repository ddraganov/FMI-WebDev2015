using System.Collections.Generic;
using Fmi.Tests.Contracts.Dto;

namespace Fmi.Tests.Contracts.Requests.Tests
{
    public class GetAllTestsRequest : IRequest<IEnumerable<TestDto>>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
