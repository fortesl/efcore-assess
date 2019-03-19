using Fortes.Assess.Data;
using Fortes.Assess.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortes.Assess.UnitTests.Data.Repositories
{

    [TestClass]
    public class AssessModelTests
    {
        private const string IN_MEMORY_STORE = "IN_MEMORY_TESTDB";
        private readonly DbContextOptions _options;
        private readonly Assess.Data.Repositories.DisconnectedData.Repository<Assessment> _repo;

        public AssessModelTests()
        {
            _options = new DbContextOptionsBuilder<AssessDbContext>()
                .UseInMemoryDatabase(IN_MEMORY_STORE)
                .Options;
            var context = new AssessDbContext(_options);
            _repo = new Assess.Data.Repositories.DisconnectedData.Repository<Assessment>(context);
            SeedInMemoryStore();
        }

        [TestMethod]
        public async Task GeAssessments_Should_Return_All_Assessment()
        {
            var result = await _repo.GetAllAsync();

            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod]
        public async Task GetAssessment_Should_Return_An_Assessment()
        {
            var result = await _repo.GetByKeyAsync(1);

            Assert.AreEqual(result.Id, 1);
            Assert.IsNotNull(result.UserPage);
        }

        [TestMethod]
        public void TestMethod1_Should_ExpectedBehavior_When_StateUnderTest()
        {
            Assert.AreEqual(4, 2+2);
        }

        [TestMethod]
        public async Task GeAssessments_Should_Return_A_List_Of_Assessments()
        {
            var result = await _repo.GetAllAsync();

            Assert.IsInstanceOfType(result, typeof(List<Assessment>));
        }

        private void SeedInMemoryStore()
        {
            using (var context = new AssessDbContext(_options))
            {
                if (context.Assessments.Any()) return;
                context.Assessments.AddRange(
                    new Assessment()
                    {
                        Name = "CUC-101",
                        Description = "Jail Birds",
                        UserPage = new UserPage()
                        {
                            Title = "Best of the West"
                        },
                    },
                    new Assessment()
                    {
                        Name = "DELL-101",
                        Description = "Computers etc",
                        UserPage = new UserPage()
                        {
                            Title = "One in the West"
                        }
                    }
                );
                context.SaveChanges();
            }

        }
    }
}
