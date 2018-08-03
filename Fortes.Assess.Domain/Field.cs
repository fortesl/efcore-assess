using System;
using System.Collections.Generic;
using System.Text;

namespace Fortes.Assess.Domain
{
    public class Field
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Assessment> Assessments { get; set; }
    }
}
