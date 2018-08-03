using System;
using System.Collections.Generic;

namespace Fortes.Assess.Domain
{
    public class Company
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string IndustryId { get; set; }
        public List<Assessment> Assessments { get; set; }
    }
}
