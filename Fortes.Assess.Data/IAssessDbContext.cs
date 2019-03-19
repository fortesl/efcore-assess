using System.Threading.Tasks;
using Fortes.Assess.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fortes.Assess.Data
{
    public interface IAssessDbContext
    {
        DbSet<AdminPage> AdminPages { get; set; }
        DbSet<Assessment> Assessments { get; set; }
        DbSet<Company> Companies { get; set; }
        DbSet<Duration> Durations { get; set; }
        DbSet<Field> Fields { get; set; }
        DbSet<Framework> Frameworks { get; set; }
        DbSet<Industry> Industries { get; set; }
        DbSet<Level> Levels { get; set; }
        DbSet<Occupation> Occupations { get; set; }
        DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        DbSet<Question> Questions { get; set; }
        DbSet<QuestionType> QuestionTypes { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<UserPage> UserPages { get; set; }
        DbSet<User> Users { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}