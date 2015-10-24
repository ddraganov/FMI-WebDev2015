using System.Collections.Generic;
using System.Threading.Tasks;
using Fmi.Tests.Contracts.Dto;
using Fmi.Tests.Core.Services.Interfaces;

namespace Fmi.Tests.Core.Services.Services
{
    public class QuestionsService : IQuestionsService
    {
        public async Task<IEnumerable<QuestionDto>> Get()
        {
            return new List<QuestionDto>
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
            };
        }

        public async Task<QuestionDto> Get(int id)
        {
            return new QuestionDto()
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
            };
        }

        public async Task Create(CreateQuestionDto question)
        {
            //
        }

        public async Task Update(QuestionDto question)
        {
            //
        }

        public async Task Delete(int id)
        {
            //
        }
    }
}
