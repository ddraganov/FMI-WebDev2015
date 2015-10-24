using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fmi.Tests.Contracts.Dto;
using Fmi.Tests.Core.Services.Interfaces;

namespace Fmi.Tests.Core.Services.Services
{
    public class TestsService : ITestsService
    {
        public async Task<IEnumerable<BasicTestDto>> Get()
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

        public async Task<FullTestDto> Get(string code)
        {
            return new FullTestDto
            {
                Code = "Beginners",
                AuthToken = Guid.NewGuid().ToString(),
                Name = "Test For Beginners",
                Description = "Test for beginners - level 1",
                Questions = new List<CreateQuestionDto>()
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

        public async Task Create(BasicTestDto question)
        {
            //
        }

        public async Task Update(BasicTestDto question)
        {
            //
        }

        public async Task Delete(string code)
        {
            //
        }

        public async Task AddQuestions(string code, List<int> questionIdList)
        {
            //
        }

        public async Task AddQuestions(string code, List<CreateQuestionDto> questionIdList)
        {
            //
        }
    }
}
