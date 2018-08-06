using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Fortes.Assess.Domain;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Fortes.Assess.Data
{
    public class AssessDbContext : DbContext
    {
        private static string _connectionString;

        public static readonly LoggerFactory MyLoggerFactory
            = new LoggerFactory(new[]
            {
                new ConsoleLoggerProvider((category, level) 
                    => category == DbLoggerCategory.Database.Command.Name
                        && level == LogLevel.Information, true) 

            }); 

        public AssessDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public AssessDbContext(string connectionString)
        {
            if (!string.IsNullOrEmpty(connectionString) && !string.IsNullOrWhiteSpace(connectionString))
            {
                _connectionString = connectionString;
            }                
        }

        #region dbsets
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
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured && !string.IsNullOrEmpty(_connectionString))
            {
                optionsBuilder
                    .UseSqlServer(_connectionString)
                    .UseLoggerFactory(MyLoggerFactory);
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //many-to-many keys
            modelBuilder.Entity<AssessmentQuestion>()
                .HasKey(s => new {s.AssessmentId, s.QuestionId});
            modelBuilder.Entity<UserRole>()
                .HasKey(s => new {s.UserId, s.RoleId});
            modelBuilder.Entity<AssessmentUser>()
                .HasKey(s => new {s.AssessmentId, s.UserId});
            modelBuilder.Entity<QuestionTag>()
                .HasKey(s => new {s.QuestionId, s.TagId});

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                //Shadow state properties
                if (entityType.FindProperty("LastModified") == null)
                {
                    modelBuilder.Entity(entityType.Name).Property<DateTime>("LastModified");
                }

                //ignore
                modelBuilder.Entity(entityType.Name).Ignore("IsDirty");
            }

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                if (entry.Property("LastModified") != null)
                {
                    entry.Property("LastModified").CurrentValue = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }

    }
}
