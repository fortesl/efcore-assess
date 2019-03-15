using System;
using Fortes.Assess.Data.Repositories;
using Fortes.Assess.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Fortes.Assess.WebApi.Controllers
{
    public class UsersController : AssessBaseController
    {
        private readonly IRepository<User> _repo;
        private readonly ILogger _logger;
        private readonly IHttpContextAccessor _context;

        public UsersController(IRepository<User> repo, ILogger<UsersController> logger, IHttpContextAccessor context)
        {
            _repo = repo;
            _logger = logger;
            _context = context;
            _logger.LogInformation($"Host: {_context.HttpContext.Request.Host} IsAuthenticated: {_context.HttpContext.User.Identity.IsAuthenticated}");
        }

        // GET: api/users
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetUsers()
        {
            var users = _repo.GetAll();
            return Ok(users);
        }

        // GET: api/Users/get/1
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetUser(int id)
        {
            var users = (List<User>)_repo.GetAllBy(u => u.Id == id);
            User user = users.FirstOrDefault();

            if (user == null)
            {
                _logger.LogWarning($"GetUser: user {id} not found");
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/users
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddUserAsync([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning($"AddUser: BadRequest: - {ModelState}");
                return BadRequest(ModelState);
            }
            await _repo.InsertAsync(user);

            return CreatedAtAction("AddUserAsync", new { id = user.Id }, user);
        }

        // PUT: api/users/1
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ModifyUser([FromRoute] int id, [FromBody] User user)
        {
            if (!ModelState.IsValid || id != user.Id)
            {
                _logger.LogWarning($"ModifyUser: BadRequest: - {ModelState}");
                return BadRequest(ModelState);
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
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning($"DeleteUser: BadRequest: - {ModelState}");
                return BadRequest(ModelState);
            }
            var deleted = await _repo.DeleteAsync(id);
            if (deleted == null)
            {
                _logger.LogWarning($"DeleteUser: Not found {id}");
                return NotFound();
            }

            return Ok(deleted);
        }

        [HttpGet]
        [Route("isAlive")]
        [ProducesResponseType(200)]
        public IActionResult IsAlive()
        {
            string message = $"{DateTime.UtcNow.ToString(CultureInfo.CurrentCulture)} HostName: {Dns.GetHostName()} Path: {HttpContext.Request.Path}";
            return Ok(message);
        }

    }
}