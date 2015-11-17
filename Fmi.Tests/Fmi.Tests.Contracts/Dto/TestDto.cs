using System.Collections.Generic;
using FluentValidation.Attributes;
using Fmi.Tests.Contracts.Validators;

namespace Fmi.Tests.Contracts.Dto
{
    [Validator(typeof(TestValidator))]
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
