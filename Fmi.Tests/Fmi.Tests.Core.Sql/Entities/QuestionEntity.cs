using System.Collections.Generic;

namespace Fmi.Tests.Core.Sql.Entities
{
    public class QuestionEntity
    {
        public QuestionEntity()
        {
            Answers = new HashSet<AnswerEntity>();
            Tests = new HashSet<TestEntity>();
        }

        public int Id { get; set; }
        public string Text { get; set; }

        public virtual HashSet<AnswerEntity> Answers { get; set; }
        public virtual HashSet<TestEntity> Tests { get; set; }
    }
}
