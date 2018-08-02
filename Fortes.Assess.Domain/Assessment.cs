using System;
using System.Collections.Generic;

namespace Fortes.Assess.Domain
{
    public class Assessment
    {
        public Assessment()
        {
            Questions = new List<Question>();
        }
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PassingGrade { get; set; }
        public int AdminPageId { get; set; }
        public int UserPageId { get; set; }
        public string FieldId { get; set; }
        public string CompanyId { get; set; }
        public string FrameworkId { get; set; }
        public string IndustryId { get; set; }
        public string ProgrammingLanguageId { get; set; }
        public string LevelId { get; set; }
        public string OccupationId { get; set; }
        public List<Question> Questions { get; set; }
        public int UserID { get; set; }
    }
}
