using Fmi.Tests.Contracts.Dto;

namespace Fmi.Tests.Contracts.Requests.Questions
{
    public class GetQuestionRequest : IRequest<QuestionDto>
    {
        public int Id { get; set; }
    }
}
