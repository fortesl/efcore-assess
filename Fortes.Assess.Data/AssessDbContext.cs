using Microsoft.EntityFrameworkCore;
using Fortes.Assess.Domain;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Fortes.Assess.Data
{
    public class AssessDbContext : DbContext
    {
        public static readonly LoggerFactory MyLoggerFactory
            = new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });


        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<Framework> Frameworks { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<Duration> Durations { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AdminPage> AdminPages { get; set; }
        public DbSet<UserPage> UserPages { get; set; }
        public DbSet<AssessmentQuestion> AssessmentQuestion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLoggerFactory(MyLoggerFactory)
                .UseSqlServer("Server = (localdb)\\mssqllocaldb; Database= Assessment; Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssessmentQuestion>()
                .HasKey(s => new {s.AssessmentId, s.QuestionId});
            modelBuilder.Entity<UserRole>()
                .HasKey(s => new {s.UserId, s.RoleId});
            modelBuilder.Entity<AssessmentUser>()
                .HasKey(s => new {s.AssessmentId, s.UserId});
            modelBuilder.Entity<QuestionTag>()
                .HasKey(s => new { s.QuestionId, s.TagId });


            base.OnModelCreating(modelBuilder);
        }

    }
}
