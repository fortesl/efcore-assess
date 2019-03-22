using System;
using System.Collections.Generic;
using System.Text;

namespace Fortes.Assess.Domain
{
    public class QuestionTag
    {
        public int QuestionId { get; set; }
        public int TagId { get; set; }
        public virtual Question Question { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
