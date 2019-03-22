using System.Collections.Generic;

namespace Fortes.Assess.Domain
{
    public partial class User : EntityBase
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public virtual List<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public virtual List<UserAssessment> UserAssessments { get; set; } = new List<UserAssessment>();
    }
}

