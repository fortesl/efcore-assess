using System;
using System.Collections.Generic;
using System.Text;

namespace Fortes.Assess.Domain
{
    public class AdminPage
    {
        public int Id { get; set; }
        public int AssessmentId { get; set; }
        public string title { get; set; }
        public string header { get; set; }
        public string content { get; set; }
        public string footer { get; set; }
    }
}
