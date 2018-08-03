using System;
using System.Collections.Generic;
using System.Text;

namespace Fortes.Assess.Domain
{
    public class Tag
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<QuestionTag> TagQuestions { get; set; }
    }
}
