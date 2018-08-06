using System.Collections.Generic;
using System.Linq;
using Fortes.Assess.Data;
using Fortes.Assess.Data.Repositories.DisconnectedData;
using Fortes.Assess.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fortes.Assess.UnitTests.Data.Repositories
{

    [TestClass]
    public class AssessModelTests
    {
        private const string IN_MEMORY_STORE = "IN_MEMORY_TESTDB";
        private readonly DbContextOptions _options;
        private AssessDbContext _context;
        private readonly DisconnectedData _repo;

        public AssessModelTests()
        {
            _options = new DbContextOptionsBuilder<AssessDbContext>()
                .UseInMemoryDatabase(IN_MEMORY_STORE)
                .Options;
            _context = new AssessDbContext(_options);
            _repo = new DisconnectedData(_context);
            SeedInMemoryStore();
        }

        [TestMethod]
        public void GeAssessmentIds_Should_Return_All_Assessment_Ids()
        {
            var result = _repo.GeAssessmentIds();

            Assert.AreEqual(result.Count, 2);
        }

        [TestMethod]
        public void GetAssessment_Should_Return_An_Assessment()
        {
            var result = _repo.GetAssessment("CUC-101");

            Assert.AreEqual(result.Id, "CUC-101");
            Assert.AreEqual(result.UserPage.Title, "Best of the West");
        }

        [TestMethod]
        public void TestMethod1_Should_ExpectedBehavior_When_StateUnderTest()
        {
            Assert.AreEqual(4, 2+2);
        }

        [TestMethod]
        public void GeAssessmentIds_Should_ReturnListOfStrings()
        {
            var result = _repo.GeAssessmentIds();

            Assert.IsInstanceOfType(result, typeof(List<string>));
        }

        private void SeedInMemoryStore()
        {
            using (var context = new AssessDbContext(_options))
            {
                if (!context.Assessments.Any())
                {
                    context.Assessments.AddRange(
                        new Assessment()
                        {
                            Id = "CUC-101",
                            Description = "Jail Birds",
                            UserPage = new UserPage()
                            {
                                Title = "Best of the West"
                            }
                        },
                        new Assessment()
                        {
                            Id = "DELL-101",
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
}
