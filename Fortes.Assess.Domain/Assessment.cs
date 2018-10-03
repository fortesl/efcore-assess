using System;
using System.Collections.Generic;

namespace Fortes.Assess.Domain
{
    public class Assessment
    {
        public Assessment()
        {
            AssessmentQuestions = new List<AssessmentQuestion>();
            AssessmentUsers = new List<AssessmentUser>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? PassingGrade { get; set; }
        public AdminPage AdminPage { get; set; }
        public UserPage UserPage { get; set; }
        public Field Field { get; set; }
        public Company Company { get; set; }
        public Framework Framework { get; set; }
        public Industry Industry { get; set; }
        public ProgrammingLanguage ProgrammingLanguage { get; set; }
        public Level Level { get; set; }
        public Occupation Occupation { get; set; }
        public Duration Duration { get; set; }
        public List<AssessmentQuestion> AssessmentQuestions { get; set; }
        public List<AssessmentUser> AssessmentUsers { get; set; }
        public DateTime LastModified { get; set; }
    }
}
