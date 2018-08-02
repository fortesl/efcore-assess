using Microsoft.EntityFrameworkCore;
using Fortes.Assess.Domain;

namespace Fortes.Assess.Data
{
    public class AssessDbContext : DbContext
    {
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database= Assess; Trusted_Connection=True;");
        }

    }
}
