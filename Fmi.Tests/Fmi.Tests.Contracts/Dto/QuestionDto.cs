using System.Collections.Generic;

namespace Fmi.Tests.Contracts.Dto
{
    public class QuestionDto
    {
        public QuestionDto()
        {
            Answers = new List<AnswerDto>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public List<AnswerDto> Answers { get; set; }
    }
}
