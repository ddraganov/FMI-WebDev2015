using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fmi.Tests.Contracts.Dto;
using Fmi.Tests.Contracts.Requests.Tests;
using Fmi.Tests.Core.Handlers.Interfaces;

namespace Fmi.Tests.Core.Handlers.Features.Tests
{
    public class GetAllTestsHandler : IRequestHandler<GetAllTestsRequest, IEnumerable<BasicTestDto>>
    {
        public async Task<IEnumerable<BasicTestDto>> HandleAsync(GetAllTestsRequest request)
        {
            return new List<BasicTestDto>
            {
                new BasicTestDto
                {
                    Code = "Beginners",
                    AuthToken = Guid.NewGuid().ToString(),
                    Name = "Test For Beginners",
                    Description = "Test for beginners - level 1"
                },
                new BasicTestDto
                {
                    Code = "Advanced",
                    AuthToken = Guid.NewGuid().ToString(),
                    Name = "Test For Gurus",
                    Description = "Test for Gurus - level 1"
                }
            };
        }
    }
}
