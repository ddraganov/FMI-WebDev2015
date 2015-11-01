using System.Collections.Generic;

namespace Fmi.Tests.Contracts.Dto
{
    public class TestDto
    {
        public TestDto()
        {
            Questions = new List<QuestionDto>();
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AuthToken { get; set; }
        public List<QuestionDto> Questions { get; set; }
    }
}
