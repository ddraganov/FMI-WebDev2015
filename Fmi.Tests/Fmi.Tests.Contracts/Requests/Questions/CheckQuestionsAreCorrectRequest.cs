using System.Collections.Generic;

namespace Fmi.Tests.Contracts.Requests.Questions
{
    public class CheckQuestionsAreCorrectRequest : IRequest<Dictionary<int, bool>>
    {
        public Dictionary<int, int> QuestionAnswers { get; set; }
    }
}
