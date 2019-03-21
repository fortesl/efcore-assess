using System;
using Fortes.Assess.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fortes.Assess.Data.EF
{
    public static class InitializeDataBase
    {

        public static void ConfigureEntities(ModelBuilder modelBuilder)
        {
            var assessment = modelBuilder.Entity<Assessment>();
            var user = modelBuilder.Entity<User>();

            assessment.Property(e => e.Name).HasMaxLength(50).IsRequired();

            user.Property(e => e.Email).HasMaxLength(50).IsRequired();
            user.Property(e => e.FirstName).HasMaxLength(50).IsRequired();
            user.Property(e => e.LastName).HasMaxLength(50).IsRequired();

            modelBuilder.Entity<Company>().Property(e => e.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Duration>().Property(e => e.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Field>().Property(e => e.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Framework>().Property(e => e.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Industry>().Property(e => e.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Level>().Property(e => e.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Occupation>().Property(e => e.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<ProgrammingLanguage>().Property(e => e.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<QuestionType>().Property(e => e.Name).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Tag>().Property(e => e.Name).HasMaxLength(50).IsRequired();

        }

        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "Fortes Systems", IndustryId = 7 }
            );

            modelBuilder.Entity<Duration>().HasData(
                new  { Id = 1, Name = "1 Minute" },
                new  { Id = 2, Name = "5 Minutes" },
                new  { Id = 3, Name = "10 Minutes" },
                new  { Id = 4, Name = "15 Minutes" },
                new  { Id = 5, Name = "20 Minutes" },
                new  { Id = 6, Name = "20 Minutes" },
                new  { Id = 7, Name = "30 Minutes" },
                new  { Id = 8, Name = "45 Minutes" },
                new  { Id = 9, Name = "60 Minutes" },
                new  { Id = 10, Name = "90 Minutes" },
                new  { Id = 11, Name = "120 Minutes" }
            );

            modelBuilder.Entity<Framework>().HasData(
                new { Id = 1, Name = ".NET" },
                new { Id = 2, Name = ".NET Core" },
                new { Id = 3, Name = "Java" },
                new { Id = 4, Name = "Angular" },
                new { Id = 5, Name = "React" },
                new { Id = 6, Name = "Node" }
            );

            modelBuilder.Entity<Industry>().HasData(
                new { Id = 1, Name = "Health" },
                new { Id = 2, Name = "Manufacturing" },
                new { Id = 3, Name = "Finances" },
                new { Id = 4, Name = "Banking" },
                new { Id = 5, Name = "Government" },
                new { Id = 6, Name = "Entertaiment" },
                new { Id = 7, Name = "Technology" },
                new { Id = 8, Name = "Music" }
            );

            modelBuilder.Entity<Level>().HasData(
                new { Id = 1, Name = "Senior Level" },
                new { Id = 2, Name = "Junior Level" },
                new { Id = 3, Name = "Intermediate Level" },
                new { Id = 4, Name = "Beginner" },
                new { Id = 5, Name = "Internship" },
                new { Id = 6, Name = "Expert Level" }
            );

            modelBuilder.Entity<Occupation>().HasData(
                new { Id = 2, Name = "Architect" },
                new { Id = 3, Name = "Software Tester" },
                new { Id = 4, Name = "Software Developer - Full Stack" },
                new { Id = 5, Name = "Software Developer - Frontend" },
                new { Id = 6, Name = "Software Developer - Backend" },
                new { Id = 7, Name = "Designer" }
            );

            modelBuilder.Entity<ProgrammingLanguage>().HasData(
                new { Id = 1, Name = "C#" },
                new { Id = 2, Name = "Java" },
                new { Id = 3, Name = "Javascript" },
                new { Id = 4, Name = "C++" }
            );

            modelBuilder.Entity<QuestionType>().HasData(
                new { Id = 1, Name = "Multiple Choice" },
                new { Id = 2, Name = "True/False" },
                new { Id = 3, Name = "Essay" }
            );

            modelBuilder.Entity<Role>().HasData(
                new { Id = 1, Name = "Admin" },
                new { Id = 2, Name = "User" },
                new { Id = 4, Name = "Superuser" }
            );

            modelBuilder.Entity<Tag>().HasData(
                new { Id = 1, Name = ".NET" },
                new { Id = 2, Name = ".NET Core" },
                new { Id = 3, Name = "Java" },
                new { Id = 4, Name = "Angular" },
                new { Id = 5, Name = "React" },
                new { Id = 6, Name = "Node" },
                new { Id = 7, Name = "C#" },
                new { Id = 8, Name = "Java" },
                new { Id = 9, Name = "Javascript" },
                new { Id = 10, Name = "C++", }
            );

            modelBuilder.Entity<User>().HasData(
                new { Id = 1, FirstName = "Luis", LastName = "Fortes", Email = "lmlf100@gmail.com", CompanyId = 1 }
            );

        }
    }
}
