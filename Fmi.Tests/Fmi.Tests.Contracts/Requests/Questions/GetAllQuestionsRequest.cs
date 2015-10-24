using System.Collections.Generic;
using Fmi.Tests.Contracts.Dto;

namespace Fmi.Tests.Contracts.Requests.Questions
{
    public class GetAllQuestionsRequest : IRequest<IEnumerable<QuestionDto>>
    { }
}
