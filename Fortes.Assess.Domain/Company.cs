using System;
using System.Collections.Generic;

namespace Fortes.Assess.Domain
{
    public class Company : EntityBase
    {
        public string Name { get; set; }
        public int? IndustryId { get; set; }
        public virtual List<Assessment> Assessments { get; set; } = new List<Assessment>();
        public virtual List<User> Users { get; set; } = new List<User>();
    }
}
