using System.Collections.Generic;

namespace Fmi.Tests.Contracts.Dto
{
    public class CreateQuestionDto
    {
        public CreateQuestionDto()
        {
            Answers = new List<AnswerDto>();
        }

        public string Text { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
}
