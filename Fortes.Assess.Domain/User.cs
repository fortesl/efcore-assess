using System;
using System.Collections.Generic;

namespace Fortes.Assess.Domain
{
    public class User
    {
        public User()
        {
            UserAssessments = new List<AssessmentUser>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public int CompanyId { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }
        public List<AssessmentUser> UserAssessments { get; set; }
        public DateTime LastModified { get; set; }
    }
}
