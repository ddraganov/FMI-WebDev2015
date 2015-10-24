using System.Collections.Generic;
using System.Threading.Tasks;
using Fmi.Tests.Contracts.Dto;
using Fmi.Tests.Contracts.Requests.Questions;
using Fmi.Tests.Core.Handlers.Interfaces;

namespace Fmi.Tests.Core.Handlers.Features.Questions
{
    public class GetAllQuestionsHandler : IRequestHandler<GetAllQuestionsRequest, IEnumerable<QuestionDto>>
    {
        public async Task<IEnumerable<QuestionDto>> HandleAsync(GetAllQuestionsRequest request)
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
    }
}
