using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Fortes.Assess.Data.Repositories;
using Fortes.Assess.Domain;
using Fortes.Assess.Data.Repositories.DisconnectedData;
using Fortes.Assess.Data;

namespace Fortes.Assess.WebApi.Controllers
{
    [Route("api/[controller]")]
#if NETCOREAPP2_1
    [ApiController]
#endif
    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _repo;

        public UserController(Repository<User> repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<User> GetUsers(int id)
        {
            return _repo.AllInclude("UserRoles", "UserAssessments");
        }

        [HttpGet("{id}")]
        public User GetUser(int id)
        {
            return _repo.FindByKey(id);
        }

        [HttpPost]
        public void AddUser([FromBody] User user)
        {
            _repo.Insert(user);
        }

        [HttpPut("{id}")]
        public void ModifyUser(string id, [FromBody] User user)
        {
            _repo.Update(user);
        }

        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
            _repo.Delete(id);
        }

    }
}