using System;
using System.Collections.Generic;
using System.Text;

namespace Fortes.Assess.Domain
{
    public class AssessmentUser
    {
        public string AssessmentId { get; set; }
        public int UserId { get; set; }
        public string RoleId { get; set; }
        public User User { get; set; }
        public Assessment Assessment { get; set; }
    }
}
