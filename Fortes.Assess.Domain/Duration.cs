using System;
using System.Collections.Generic;
using System.Text;

namespace Fortes.Assess.Domain
{
    public class Duration
    {
        public Duration()
        {
            Questions = new List<Question>();
            Assessments = new List<Assessment>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
        public List<Assessment> Assessments { get; set; }
    }
}
