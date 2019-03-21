using System.Collections.Generic;

namespace Fortes.Assess.Domain
{
    public class Question : EntityBase
    {
        public string CreatedBy { get; set; }
        public string Description { get; set; }
        public string Explanation { get; set; }
        public virtual Duration Duration { get; set; }
        public virtual Level Level { get; set; }
        public virtual QuestionType QuestionType { get; set; }
        public virtual ICollection<ChoiceOption> ChoiceOptions { get; set; } = new List<ChoiceOption>();
        public virtual ICollection<AssessmentQuestion> QuestionAssessments { get; set; } = new List<AssessmentQuestion>();
        public virtual ICollection<QuestionTag> QuestionTags { get; set; } = new List<QuestionTag>();
    }

    public class ChoiceOption : EntityBase
    {
        public int QuestionId { get; set; }
        public string Description { get; set; }
        public bool IsCorrect { get; set; }
    }

}
