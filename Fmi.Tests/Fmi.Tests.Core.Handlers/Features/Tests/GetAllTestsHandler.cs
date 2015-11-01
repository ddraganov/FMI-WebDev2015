using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fmi.Tests.Contracts.Dto;
using Fmi.Tests.Contracts.Requests.Tests;
using Fmi.Tests.Core.Handlers.Interfaces;

namespace Fmi.Tests.Core.Handlers.Features.Tests
{
    public class GetAllTestsHandler : IRequestHandler<GetAllTestsRequest, IEnumerable<TestDto>>
    {
        public async Task<IEnumerable<TestDto>> HandleAsync(GetAllTestsRequest request)
        {
            return new List<TestDto>
            {
                new TestDto
                {
                    Code = "Beginners",
                    AuthToken = Guid.NewGuid().ToString(),
                    Name = "Test For Beginners",
                    Description = "Test for beginners - level 1"
                },
                new TestDto
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
