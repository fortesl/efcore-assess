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
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? PassingGrade { get; set; }
        public int? AdminPageId { get; set; }
        public AdminPage AdminPage { get; set; }
        public int? UserPageId { get; set; }
        public UserPage UserPage { get; set; }
        public int? FieldId { get; set; }
        public int? CompanyId { get; set; }
        public int? FrameworkId { get; set; }
        public int? IndustryId { get; set; }
        public int? ProgrammingLanguageId { get; set; }
        public int? LevelId { get; set; }
        public int? OccupationId { get; set; }
        public int? DurationId { get; set; }
        public List<AssessmentQuestion> AssessmentQuestions { get; set; }
        public List<AssessmentUser> AssessmentUsers { get; set; }
        public DateTime LastModified { get; set; }
    }
}
