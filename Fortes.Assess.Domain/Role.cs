using System;
using System.Collections.Generic;
using System.Text;

namespace Fortes.Assess.Domain
{
    public class Role
    {
        public Role()
        {
            RoleUsers = new List<UserRole>();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public List<UserRole> RoleUsers { get; set; }
    }
}
