using System.Collections.Generic;

namespace Fortes.Assess.Domain
{
    public class ProgrammingLanguage
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Assessment> Assessments { get; set; }
    }
}
