using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fmi.Tests.Contracts.Dto;
using Fmi.Tests.Core.Services.Interfaces;

namespace Fmi.Tests.Core.Services.Services
{
    public class TestsService : ITestsService
    {
        public async Task<IEnumerable<TestDto>> Get(int skip, int take)
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

        public async Task<TestDto> Get(string code)
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

        public async Task Create(TestDto question)
        {
            //
        }

        public async Task Update(TestDto question, string authToken)
        {
            //
        }

        public async Task Delete(string id, string authToken)
        {
            //
        }

        public async Task AddQuestions(string code, List<int> questionIdList, string authToken)
        {
            //
        }

        public async Task AddQuestions(string code, List<QuestionDto> questionIdList)
        {
            //
        }
    }
}
