using System.Collections.Generic;

namespace Fortes.Assess.Domain
{
    public class User
    {
        public User()
        {
            Assessments = new List<Assessment>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string email { get; set; }
        public string CompanyId { get; set; }
        public List<Role> Roles { get; set; }
        public List<Assessment> Assessments { get; set; }
    }
}
