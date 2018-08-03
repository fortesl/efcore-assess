using System;
using System.Collections.Generic;
using System.Text;

namespace Fortes.Assess.Domain
{
    public class AssessmentQuestion
    {
        public string QuestionId { get; set; }
        public string AssessmentId { get; set; }
        public Question Question { get; set; }
        public Assessment Assessment { get; set; }
    }
}
