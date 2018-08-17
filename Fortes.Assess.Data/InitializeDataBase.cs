using Fortes.Assess.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Fortes.Assess.Data
{
    public static class InitializeDataBase
    {
#if !NETCOREAPP2_0
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new { Id = 1, Name = "User", LastModified = DateTime.Now },
                new  { Id = 2, Name = "Admin", LastModified = DateTime.Now },
                new  { Id = 3, Name = "AssessmentAdmin", LastModified = DateTime.Now }
            );

            modelBuilder.Entity<User>().HasData(
                new  { Id = 1, Name = "Luis Fortes",  LastName = "Fortes", FirstName = "Luis", Email = "lmlf100@gmail.com", LastModified = DateTime.Now }
            );

            modelBuilder.Entity<UserRole>().HasData(
                new  { UserId = 1, RoleId = 2, LastModified = DateTime.Now }
            );
        }
#endif
    }
}
