namespace Fortes.Assess.Domain
{
    public class UserAssessment
    {
        public int AssessmentId { get; set; }
        public int UserId { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
        public virtual Assessment Assessment { get; set; }
    }
}
