using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fmi.Tests.Contracts.Dto;
using Fmi.Tests.Contracts.Requests.Tests;
using Fmi.Tests.Core.Handlers.Interfaces;

namespace Fmi.Tests.Core.Handlers.Features.Tests
{
    public class GetTestHandler : IRequestHandler<GetTestRequest, TestDto>
    {
        public async Task<TestDto> HandleAsync(GetTestRequest request)
        {
            return new TestDto
            {
                Code = "Beginners",
                AuthToken = Guid.NewGuid().ToString(),
                Name = "Test For Beginners",
                Description = "Test for beginners - level 1",
                Questions = new List<QuestionDto>()
                {
                    new QuestionDto()
                    {
                        Id = 1,
                        Text = "What's your name?",
                        Answers = new List<AnswerDto>
                        {
                            new AnswerDto()
                            {
                                Id = 1,
                                IsCorrect = true,
                                Text = "John"
                            },
                            new AnswerDto()
                            {
                                Id = 2,
                                IsCorrect = false,
                                Text = "Doe"
                            }
                        }
                    },
                    new QuestionDto()
                    {
                        Id = 2,
                        Text = "What's your surname?",
                        Answers = new List<AnswerDto>
                        {
                            new AnswerDto()
                            {
                                Id = 1,
                                IsCorrect = false,
                                Text = "John"
                            },
                            new AnswerDto()
                            {
                                Id = 2,
                                IsCorrect = true,
                                Text = "Doe"
                            }
                        }
                    }
                }
            };
        }
    }
}
