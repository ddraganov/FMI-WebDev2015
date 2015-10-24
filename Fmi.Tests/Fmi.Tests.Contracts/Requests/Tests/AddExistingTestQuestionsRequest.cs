using System.Collections.Generic;

namespace Fmi.Tests.Contracts.Requests.Tests
{
    public class AddExistingTestQuestionsRequest : IRequest
    {
        public List<int> QuestionIdList { get; set; } 
    }
}
