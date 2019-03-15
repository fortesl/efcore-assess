using System;
using System.Linq;
using Fortes.Assess.Data;
using Fortes.Assess.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fortes.Assess.UnitTests.Data
{
    class MockData : IDisposable
    {
        public readonly AssessDbContext DbContext;

        public MockData(string dbName)
        {
            var options = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(databaseName: dbName)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll)
                .Options;

            DbContext = new AssessDbContext(options);

            DbContext.Database.EnsureCreated();

            CreateMockData(DbContext);
            DbContext.SaveChanges();
        }

        private static void CreateMockData(AssessDbContext context)
        {

            //Users
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User
                    {
                        Name = "Luis Fortes",
                        FirstName = "Luis",
                        LastName = "Fortes",
                        Email = "lmlf100@gmail.com"
                    });
            }
        }

        public void Dispose()
        {
            DbContext.Database.EnsureDeleted();
        }
    }
}
