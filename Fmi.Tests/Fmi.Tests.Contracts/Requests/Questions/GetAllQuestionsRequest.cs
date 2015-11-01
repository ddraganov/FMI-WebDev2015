using System.Collections.Generic;
using Fmi.Tests.Contracts.Dto;

namespace Fmi.Tests.Contracts.Requests.Questions
{
    public class GetAllQuestionsRequest : IRequest<IEnumerable<QuestionDto>>
    {
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
