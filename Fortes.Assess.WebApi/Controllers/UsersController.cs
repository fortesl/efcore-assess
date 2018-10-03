using Fortes.Assess.Data.Repositories;
using Fortes.Assess.Data.Repositories.DisconnectedData;
using Fortes.Assess.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fortes.Assess.Data.Repositories;
using Fortes.Assess.Domain;
using Fortes.Assess.Data.Repositories.DisconnectedData;
using Microsoft.Extensions.Logging;

namespace Fortes.Assess.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository<User> _repo;
        private readonly ILogger _logger;

        public UsersController(Repository<User> repo, ILogger<UsersController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        // GET: api/users
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            _logger.LogWarning("Getting users");
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
            _logger.LogWarning($"Got user {id}: ", user);
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

            return CreatedAtAction("AddUser", new { id = user.Id }, user);
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