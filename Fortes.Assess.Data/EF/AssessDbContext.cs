namespace Fortes.Assess.Data.EF
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Fortes.Assess.Domain;
    using Microsoft.EntityFrameworkCore;

    public partial class AssessDbContext : DbContext, IAssessDbContext
    {

        #region constructors

        private readonly string _connectionString;

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
            else
            {
                throw new ArgumentNullException("Empty ConnectionString given!");
            }
        }

        #endregion

        #region overrides

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured && !string.IsNullOrEmpty(_connectionString))
            {
                optionsBuilder
                    .UseSqlServer(_connectionString)
                    .EnableSensitiveDataLogging();

                base.OnConfiguring(optionsBuilder);
            }
        }

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
