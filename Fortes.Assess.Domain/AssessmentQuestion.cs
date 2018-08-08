using System;
using System.Collections.Generic;
using System.Text;

namespace Fortes.Assess.Domain
{
    public class AssessmentQuestion
    {
        public int QuestionId { get; set; }
        public int AssessmentId { get; set; }
        public Question Question { get; set; }
        public Assessment Assessment { get; set; }
    }
}
