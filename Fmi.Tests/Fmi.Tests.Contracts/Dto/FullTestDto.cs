using System.Collections.Generic;

namespace Fmi.Tests.Contracts.Dto
{
    public class FullTestDto : BasicTestDto
    {
        public FullTestDto()
        {
            Questions = new List<CreateQuestionDto>();
        }

        public List<CreateQuestionDto> Questions { get; set; }
    }
}
