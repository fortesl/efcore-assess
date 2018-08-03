using System;
using System.Collections.Generic;
using System.Text;

namespace Fortes.Assess.Domain
{
    public class Question
    {
        public Question()
        {
            Options = new List<Option>();
            AssessmentQuestions = new List<AssessmentQuestion>();
        }
        public string Id { get; set; }
        public List<Tag> Tags { get; set; }
        public string CreatedBy { get; set; }
        public string Description { get; set; }
        public string Explanation { get; set; }
        public string DurationId { get; set; }
        public string LevelId { get; set; }
        public string TypeId { get; set; }
        public List<Option> Options { get; set; }
        public List<AssessmentQuestion> AssessmentQuestions { get; set; }
    }

    public class Option
    {
        public int Id { get; set; }
        public string QuestionId { get; set; }
        public string Description { get; set; }
        public bool IsCorrect { get; set; }
    }

}
