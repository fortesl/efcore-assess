using System;
using System.Collections.Generic;
using System.Text;

namespace Fortes.Assess.Domain
{
    public class UserRole
    {
        public int UserId { get; set; }
        public string RoleId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
