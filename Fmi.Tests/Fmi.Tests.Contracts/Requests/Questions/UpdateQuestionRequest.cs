using Fmi.Tests.Contracts.Dto;

namespace Fmi.Tests.Contracts.Requests.Questions
{
    public class UpdateQuestionRequest : IRequest
    {
        public QuestionDto Question { get; set; }
    }
}
