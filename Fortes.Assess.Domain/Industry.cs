using System.Collections.Generic;

namespace Fortes.Assess.Domain
{
    public class Industry
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Assessment> Assessments { get; set; }
        public List<Company> Companies { get; set; }
    }
}
