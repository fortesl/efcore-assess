using System.Collections.Generic;

namespace Fortes.Assess.Domain
{
    public class User
    {
        public User()
        {
            AssessmentUsers = new List<AssessmentUser>();
            UserRoles = new List<UserRole>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string email { get; set; }
        public string CompanyId { get; set; }
        public List<UserRole> UserRoles { get; set; }
        public List<AssessmentUser> AssessmentUsers { get; set; }
    }
}
