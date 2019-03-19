using System;
using System.Linq;
using System.Threading.Tasks;
using Fortes.Assess.Data.Repositories.DisconnectedData;
using Fortes.Assess.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fortes.Assess.UnitTests.Data.Repositories.DisconnectedData
{
    [TestClass]
    public class RepositoryTests : IDisposable
    {
        private const string IN_MEMORY_ASSESS_TEST_DB = "TESTDB";
        private readonly MockData _mockData = new MockData(IN_MEMORY_ASSESS_TEST_DB);
        private Repository<User> _repo;

        public RepositoryTests()
        {
            _repo = new Repository<User>(_mockData.DbContext);
        }

        [TestMethod]
        public void Test_Method_Should_ExpectedBehavior_When_StateUnderTest()
        {
            Assert.AreEqual(4, 2 + 2);
        }

        [TestMethod]
        public async Task Test_GetAll_Should_ReturnAllEntities()
        {
            var list = await _repo.GetAllAsync();

            Assert.AreEqual(list.Count(), 1);
        }

        public void Dispose()
        {
            _mockData.Dispose();
        }
    }
}
