namespace Fortes.Assess.WebApi.Controllers
{
    #region usings

    using System;
    using Data.Repositories;
    using Domain;
    using Microsoft.AspNetCore.Mvc;
    using System.Globalization;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;

    #endregion

    public class UsersController : BaseController
    {
        #region constructor

        private readonly IRepository<User> _repo;
        private readonly ILogger _logger;

        #endregion

        #region Public Methods

        public UsersController(IRepository<User> repo, ILogger<UsersController> logger, IHttpContextAccessor context)
        {
            _logger = logger ?? throw new ArgumentNullException($"logger is not defined!");
            _repo = repo ?? throw new ArgumentNullException($"User repository is not defined!");

            var httpcontext = context ?? throw new ArgumentNullException($"htttpcontext is not defined");
            _logger.LogInformation($"Host: {httpcontext.HttpContext.Request.Host} IsAuthenticated: {httpcontext.HttpContext.User.Identity.IsAuthenticated}");
        }

        /// <summary>
        /// GET: api/users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repo.GetAllAsync());
        }

        /// <summary>
        /// GET: api/Users/id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid id {id}");
                return BadRequest();
            }
            var user = await _repo.GetByKeyAsync(id);
            if (user == null)
            {
                _logger.LogWarning($"GetUser: user {id} not found");
                return NotFound();
            }
            return Ok(user);
        }

        /// <summary>
        /// POST: api/users
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"AddUser: BadRequest: - {ModelState}");
                return BadRequest(ModelState);
            }
            await _repo.ModifyAsync(user);

            return CreatedAtAction("Post", new { id = user.Id }, user);
        }

        /// <summary>
        /// PUT: api/users/id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] User user)
        {
            if (!ModelState.IsValid || id != user.Id)
            {
                _logger.LogError($"ModifyUser: BadRequest: - {ModelState}");
                return BadRequest(ModelState);
            }

            var updated = await _repo.ModifyAsync(user);
            if (updated == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        
        /// <summary>
        /// DELETE: api/users/id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"DeleteUser: BadRequest: - {ModelState}");
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

        /// <summary>
        /// Is controller alive
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("isAlive")]
        [ProducesResponseType(200)]
        public IActionResult IsAlive()
        {
            string message = $"{DateTime.UtcNow.ToString(CultureInfo.CurrentCulture)} HostName: {Dns.GetHostName()} Path: {HttpContext.Request.Path}";
            return Ok(message);
        }

        #endregion

    }
}