﻿namespace Fortes.Assess.Domain
{
    public class UserAssessment
    {
        public int AssessmentId { get; set; }
        public int UserId { get; set; }
        public Role Role { get; set; }
        public User User { get; set; }
        public Assessment Assessment { get; set; }
    }
}