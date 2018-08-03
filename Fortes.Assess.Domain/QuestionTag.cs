using System;
using System.Collections.Generic;
using System.Text;

namespace Fortes.Assess.Domain
{
    public class QuestionTag
    {
        public string QuestionId { get; set; }
        public string TagId { get; set; }
        public Question Question { get; set; }
        public Tag Tag { get; set; }
    }
}
