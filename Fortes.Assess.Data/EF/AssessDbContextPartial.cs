using Fortes.Assess.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fortes.Assess.Data.EF
{
    public partial class AssessDbContext : DbContext, IAssessDbContext
    {
        #region dbsets
        public virtual DbSet<Assessment> Assessments { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<Framework> Frameworks { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<Duration> Durations { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public DbSet<AdminPage> AdminPages { get; set; }
        public DbSet<UserPage> UserPages { get; set; }
        #endregion
    }
}
