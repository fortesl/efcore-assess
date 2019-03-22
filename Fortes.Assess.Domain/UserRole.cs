namespace Fortes.Assess.Domain
{
    public class UserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int AssessmentId { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
