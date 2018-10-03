namespace Fortes.Assess.Domain
{
    public class AdminPage
    {
        public int Id { get; set; }
        public int AssessmentId { get; set; }
        public string Title { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public string Footer { get; set; }
    }
}
