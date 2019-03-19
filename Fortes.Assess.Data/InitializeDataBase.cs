using Fortes.Assess.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Assessment = Fortes.Assess.Domain.Assessment;

namespace Fortes.Assess.Data
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
            user.Property(e => e.Name).HasMaxLength(50).IsRequired();

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
                new Company { Id = 1, Name = "Fortes Systems", IndustryId = 7, LastModified = DateTime.Now }
            );

            modelBuilder.Entity<Duration>().HasData(
                new  { Id = 1, Name = "1 Minute", LastModified = DateTime.Now },
                new  { Id = 2, Name = "5 Minutes", LastModified = DateTime.Now },
                new  { Id = 3, Name = "10 Minutes", LastModified = DateTime.Now },
                new  { Id = 4, Name = "15 Minutes", LastModified = DateTime.Now },
                new  { Id = 5, Name = "20 Minutes", LastModified = DateTime.Now },
                new  { Id = 6, Name = "20 Minutes", LastModified = DateTime.Now },
                new  { Id = 7, Name = "30 Minutes", LastModified = DateTime.Now },
                new  { Id = 8, Name = "45 Minutes", LastModified = DateTime.Now },
                new  { Id = 9, Name = "60 Minutes", LastModified = DateTime.Now },
                new  { Id = 10, Name = "90 Minutes", LastModified = DateTime.Now },
                new  { Id = 11, Name = "120 Minutes", LastModified = DateTime.Now }
            );

            modelBuilder.Entity<Framework>().HasData(
                new { Id = 1, Name = ".NET", LastModified = DateTime.Now },
                new { Id = 2, Name = ".NET Core", LastModified = DateTime.Now },
                new { Id = 3, Name = "Java", LastModified = DateTime.Now },
                new { Id = 4, Name = "Angular", LastModified = DateTime.Now },
                new { Id = 5, Name = "React", LastModified = DateTime.Now },
                new { Id = 6, Name = "Node", LastModified = DateTime.Now }
            );

            modelBuilder.Entity<Industry>().HasData(
                new { Id = 1, Name = "Health", LastModified = DateTime.Now },
                new { Id = 2, Name = "Manufacturing", LastModified = DateTime.Now },
                new { Id = 3, Name = "Finances", LastModified = DateTime.Now },
                new { Id = 4, Name = "Banking", LastModified = DateTime.Now },
                new { Id = 5, Name = "Government", LastModified = DateTime.Now },
                new { Id = 6, Name = "Entertaiment", LastModified = DateTime.Now },
                new { Id = 7, Name = "Technology", LastModified = DateTime.Now },
                new { Id = 8, Name = "Music", LastModified = DateTime.Now }
            );

            modelBuilder.Entity<Level>().HasData(
                new { Id = 1, Name = "Senior Level", LastModified = DateTime.Now },
                new { Id = 2, Name = "Junior Level", LastModified = DateTime.Now },
                new { Id = 3, Name = "Intermediate Level", LastModified = DateTime.Now },
                new { Id = 4, Name = "Beginner", LastModified = DateTime.Now },
                new { Id = 5, Name = "Internship", LastModified = DateTime.Now },
                new { Id = 6, Name = "Expert Level", LastModified = DateTime.Now }
            );

            modelBuilder.Entity<Occupation>().HasData(
                new { Id = 2, Name = "Architect", LastModified = DateTime.Now },
                new { Id = 3, Name = "Software Tester", LastModified = DateTime.Now },
                new { Id = 4, Name = "Software Developer - Full Stack", LastModified = DateTime.Now },
                new { Id = 5, Name = "Software Developer - Frontend", LastModified = DateTime.Now },
                new { Id = 6, Name = "Software Developer - Backend", LastModified = DateTime.Now },
                new { Id = 7, Name = "Designer", LastModified = DateTime.Now }
            );

            modelBuilder.Entity<ProgrammingLanguage>().HasData(
                new { Id = 1, Name = "C#", LastModified = DateTime.Now },
                new { Id = 2, Name = "Java", LastModified = DateTime.Now },
                new { Id = 3, Name = "Javascript", LastModified = DateTime.Now },
                new { Id = 4, Name = "C++", LastModified = DateTime.Now }
            );

            modelBuilder.Entity<QuestionType>().HasData(
                new { Id = 1, Name = "Multiple Choice", LastModified = DateTime.Now },
                new { Id = 2, Name = "True/False", LastModified = DateTime.Now },
                new { Id = 3, Name = "Essay", LastModified = DateTime.Now }
            );

            modelBuilder.Entity<Role>().HasData(
                new { Id = 1, Name = "Admin", LastModified = DateTime.Now },
                new { Id = 2, Name = "User", LastModified = DateTime.Now },
                new { Id = 4, Name = "Superuser", LastModified = DateTime.Now }
            );

            modelBuilder.Entity<Tag>().HasData(
                new { Id = 1, Name = ".NET", LastModified = DateTime.Now },
                new { Id = 2, Name = ".NET Core", LastModified = DateTime.Now },
                new { Id = 3, Name = "Java", LastModified = DateTime.Now },
                new { Id = 4, Name = "Angular", LastModified = DateTime.Now },
                new { Id = 5, Name = "React", LastModified = DateTime.Now },
                new { Id = 6, Name = "Node", LastModified = DateTime.Now },
                new { Id = 7, Name = "C#", LastModified = DateTime.Now },
                new { Id = 8, Name = "Java", LastModified = DateTime.Now },
                new { Id = 9, Name = "Javascript", LastModified = DateTime.Now },
                new { Id = 10, Name = "C++", LastModified = DateTime.Now }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "Luis", LastName = "Fortes", Email = "lmlf100@gmail.com", Name = "Luis Fortes", CompanyId = 1, LastModified = DateTime.Now}
            );

        }
    }
}
