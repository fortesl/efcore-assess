using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Principal;
using System.Text;

namespace Fortes.Assess.Domain
{
    public class QuestionType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
    }
}
