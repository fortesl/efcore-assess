using System;
using System.Collections.Generic;
using System.Text;

namespace Fortes.Assess.Domain
{
    public class Occupation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Assessment> Assessments { get; set; }
    }
}
