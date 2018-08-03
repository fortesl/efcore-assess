using System;
using System.Collections.Generic;
using System.Text;

namespace Fortes.Assess.Domain
{
    public class Level
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
        public List<Assessment> Assessments { get; set; }
    }
}
