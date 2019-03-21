using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fortes.Assess.Domain
{
    public partial class User : EntityBase
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public int CompanyId { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public virtual ICollection<UserAssessment> UserAssessments { get; set; } = new List<UserAssessment>();
    }
}

