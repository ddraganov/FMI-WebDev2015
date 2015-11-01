using Fmi.Tests.Contracts.Dto;

namespace Fmi.Tests.Contracts.Requests.Questions
{
    public class CreateQuestionRequest : IRequest
    {
        public QuestionDto Question { get; set; }
    }
}
