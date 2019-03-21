using System;
using System.Collections.Generic;
using System.Text;

namespace Fortes.Assess.Domain
{
    public class Tag : EntityBase
    {
        public string Name { get; set; }
        public virtual ICollection<QuestionTag> TagQuestions { get; set; } = new List<QuestionTag>();
    }
}
