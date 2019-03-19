using System.Collections.Generic;

namespace Fortes.Assess.Domain
{
    public class Question
    {
        public Question()
        {
            ChoiceOptions = new List<ChoiceOption>();
            QuestionAssessments = new List<AssessmentQuestion>();
        }
        public int Id { get; set; }
        public List<QuestionTag> QuestionTags { get; set; }
        public string CreatedBy { get; set; }
        public string Description { get; set; }
        public string Explanation { get; set; }
        public Duration Duration { get; set; }
        public Level Level { get; set; }
        public QuestionType QuestionType { get; set; }
        public List<ChoiceOption> ChoiceOptions { get; set; }
        public List<AssessmentQuestion> QuestionAssessments { get; set; }
    }

    public class ChoiceOption
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Description { get; set; }
        public bool IsCorrect { get; set; }
    }

}
