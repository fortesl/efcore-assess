namespace Fortes.Assess.Domain
{
    public class AssessmentQuestion
    {
        public int QuestionId { get; set; }
        public int AssessmentId { get; set; }
        public virtual Question Question { get; set; }
        public virtual Assessment Assessment { get; set; }
    }
}
