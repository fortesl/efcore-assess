using System;
using System.Collections.Generic;
using System.Text;

namespace Fortes.Assess.Domain
{
    public class Tag : EntityBase
    {
        public string Name { get; set; }
        public virtual List<QuestionTag> TagQuestions { get; set; } = new List<QuestionTag>();
    }
}
