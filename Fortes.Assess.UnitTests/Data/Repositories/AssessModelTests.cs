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
        public void GeAssessments_Should_Return_All_Assessment()
        {
            var result = _repo.GeAssessments();

            Assert.AreEqual(result.ToList().Count, 2);
        }

        [TestMethod]
        public void GetAssessment_Should_Return_An_Assessment()
        {
            var result = _repo.GetAssessment(1);

            Assert.AreEqual(result.Id, 1);
            Assert.IsNotNull(result.UserPage);
        }

        [TestMethod]
        public void TestMethod1_Should_ExpectedBehavior_When_StateUnderTest()
        {
            Assert.AreEqual(4, 2+2);
        }

        [TestMethod]
        public void GeAssessments_Should_Return_A_List_Of_Assessments()
        {
            var result = _repo.GeAssessments();

            Assert.IsInstanceOfType(result, typeof(List<Assessment>));
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
                            Name = "CUC-101",
                            Description = "Jail Birds",
                            UserPage = new UserPage()
                            {
                                Title = "Best of the West"
                            },
                            AssessmentUsers = new List<AssessmentUser>()
                            {
                                new AssessmentUser()
                                {
                                    User = new User()
                                    {
                                        Email = "L_Fortes@Dell.com",
                                        Name = "Luis Fortes"
                                    }
                                }
                            }
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
}