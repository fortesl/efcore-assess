namespace Fortes.Assess.Domain
{
    public class AdminPage : EntityBase
    {
        public int AssessmentId { get; set; }
        public string Title { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Footer { get; set; }
    }
}
