using System;
using System.Collections.Generic;
using System.Text;

namespace Fortes.Assess.Domain
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<QuestionTag> TagQuestions { get; set; }
    }
}
