using System.Collections.Generic;

namespace Fortes.Assess.Domain
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserRole> RoleUsers { get; set; } = new List<UserRole>();
    }
}
