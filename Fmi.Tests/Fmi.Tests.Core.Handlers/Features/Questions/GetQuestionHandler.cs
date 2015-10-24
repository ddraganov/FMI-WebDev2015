using System.Collections.Generic;
using System.Threading.Tasks;
using Fmi.Tests.Contracts.Dto;
using Fmi.Tests.Contracts.Requests.Questions;
using Fmi.Tests.Core.Handlers.Interfaces;

namespace Fmi.Tests.Core.Handlers.Features.Questions
{
    public class GetQuestionHandler : IRequestHandler<GetQuestionRequest, QuestionDto>
    {
        public async Task<QuestionDto> HandleAsync(GetQuestionRequest request)
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
    }
}
