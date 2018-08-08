using System;
using System.Collections.Generic;

namespace Fortes.Assess.Domain
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? IndustryId { get; set; }
        public List<Assessment> Assessments { get; set; }
    }
}
