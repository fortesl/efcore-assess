﻿using System.Collections.Generic;

namespace Fortes.Assess.Domain
{
    public class Framework
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Assessment> Assessments { get; set; }
    }
}
