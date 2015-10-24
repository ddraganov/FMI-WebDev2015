using Fmi.Tests.Contracts.Dto;

namespace Fmi.Tests.Contracts.Requests.Questions
{
    public class CreateQuestionRequest : IRequest
    {
        public CreateQuestionDto Question { get; set; }
    }
}
