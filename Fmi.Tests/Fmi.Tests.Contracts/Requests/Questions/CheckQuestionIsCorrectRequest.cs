namespace Fmi.Tests.Contracts.Requests.Questions
{
    public class CheckQuestionIsCorrectRequest : IRequest<bool>
    {
        public int Id { get; set; }
        public int Answer { get; set; }
    }
}
