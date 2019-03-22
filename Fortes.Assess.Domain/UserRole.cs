namespace Fortes.Assess.Domain
{
    public class UserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int AssessmentId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
