using System;
using System.Linq;
using System.Threading.Tasks;
using Fortes.Assess.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Fortes.Assess.Data.EF
{
    public partial class AssessDbContext : DbContext, IAssessDbContext
    {
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

        #region overrides

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //many-to-many keys
            modelBuilder.Entity<AssessmentQuestion>()
                .HasKey(s => new { s.AssessmentId, s.QuestionId });
            modelBuilder.Entity<UserAssessment>()
                .HasKey(s => new {s.AssessmentId, s.UserId});
            modelBuilder.Entity<QuestionTag>()
                .HasKey(s => new {s.QuestionId, s.TagId});
            modelBuilder.Entity<UserRole>()
                .HasKey(s => new { s.RoleId, s.UserId });
            modelBuilder.Entity<User>()
                .Ignore("Name");

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                //ignore
                modelBuilder.Entity(entityType.Name).Ignore("IsDirty");
            }

            InitializeDataBase.ConfigureEntities(modelBuilder);
            InitializeDataBase.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            UpdateLastChanged();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            UpdateLastChanged();    
            return await base.SaveChangesAsync();
        }

        #endregion

        private void UpdateLastChanged()
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
            {
                if (entry.Property("LastChanged") != null)
                {
                    entry.Property("LastChanged").CurrentValue = DateTime.Now;
                }
            }
        }


    }
}
