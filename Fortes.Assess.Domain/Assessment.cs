using System;
using System.Collections.Generic;

namespace Fortes.Assess.Domain
{
    public class Assessment : EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? PassingGrade { get; set; }
        public virtual AdminPage AdminPage { get; set; }
        public virtual UserPage UserPage { get; set; }
        public virtual Field Field { get; set; }
        public virtual Company Company { get; set; }
        public virtual Framework Framework { get; set; }
        public virtual Industry Industry { get; set; }
        public virtual ProgrammingLanguage ProgrammingLanguage { get; set; }
        public virtual Level Level { get; set; }
        public virtual Occupation Occupation { get; set; }
        public virtual Duration Duration { get; set; }
        public virtual ICollection<AssessmentQuestion> AssessmentQuestions { get; set; } = new List<AssessmentQuestion>();
        public virtual ICollection<UserAssessment> AssessmentUsers { get; set; } = new List<UserAssessment>();
    }
}
