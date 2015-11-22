using System.Collections.Generic;

namespace Fmi.Tests.Contracts.Requests.Tests
{
    public class AddTestQuestionsRequest : IRequest
    {
        public List<int> QuestionIdList { get; set; }
        public string TestCode { get; set; }
    }
}
