using Fortes.Assess.Data.Repositories;
using Fortes.Assess.Data.Repositories.DisconnectedData;
using Fortes.Assess.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fortes.Assess.WebApi.Controllers
{
    [Route("api/[controller]")]
#if NETCOREAPP2_1
    [ApiController]
#endif
    public class UsersController : ControllerBase
    {
        private readonly IRepository<User> _repo;

        public UsersController(IRepository<User> repo)
        {
            _repo = repo;
        }

        // GET: api/users
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _repo.GetAll();
        }

        // GET: api/Users/get/1
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var users = (List<User>) _repo.GetAllBy(u => u.Id ==id);
            User user = users.FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/users
        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repo.Insert(user);

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // PUT: api/users/1
        [HttpPut("{id}")]
        public async Task<IActionResult> ModifyUser([FromRoute] int id, [FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            var updated = await _repo.UpdateAsync(id, user);
            if (updated == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/users/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var deleted = await _repo.DeleteAsync(id);
            if (deleted == null)
            {
                return NotFound();
            }

            return Ok(deleted);
        }

        [HttpGet]
        [Route("isalive")]
        public IActionResult IsAlive()
        {
            return Ok(HttpContext.Request.Path);
        }

    }
}