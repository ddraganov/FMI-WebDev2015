using System.Collections.Generic;

namespace Fmi.Tests.Core.Sql.Entities
{
    public class TestEntity
    {
        public TestEntity()
        {
            Questions = new HashSet<QuestionEntity>();
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual HashSet<QuestionEntity> Questions { get; set; }
    }
}
