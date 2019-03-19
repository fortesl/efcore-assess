namespace Fortes.Assess.WebApi.Controllers
{
    using Fortes.Assess.Data;
    using Fortes.Assess.Data.Repositories;
    using Fortes.Assess.Data.Repositories.DisconnectedData;
    using Fortes.Assess.Domain;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Globalization;
    using System.Net;
    using System.Threading.Tasks;

    /// <summary>
    /// Create, Read, Update, and Insert Controller
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CrudController : ControllerBase
    {

        #region constructors

        private readonly ILogger _logger;
        private readonly AssessDbContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">AssessDbContext dependency injection</param>
        /// <param name="logger">ILogger dependency Injection</param>
        public CrudController(AssessDbContext context, ILogger<UsersController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException("logger is not defined!");
            _context = context ?? throw new ArgumentNullException("dbcontext is not defined");
        }

        #endregion

        #region public methods

        // GET: table
        [HttpGet("{table}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Get(string table)
        {
            var repo = GetRepo(table);
            return Ok(await repo.GetAllAsync());
        }

        // GET: table/id
        [HttpGet("{table}/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Get(string table, int id)
        {
            return NotFound();
        }

        // POST: table
        [HttpPost("{table}")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> post(string table, [FromBody] object record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return CreatedAtAction("AddUserAsync", new { id = 1 }, record);
        }

        // PUT: table/id
        [HttpPut("{table}/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> put(string table, [FromRoute] int id, [FromBody] object record)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return NoContent();
        }

        // DELETE: table/id
        [HttpDelete("{table}/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> delete(string table, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }

        [HttpGet]
        [Route("isAlive")]
        [ProducesResponseType(200)]
        public IActionResult IsAlive()
        {
            string message = $"{DateTime.UtcNow.ToString(CultureInfo.CurrentCulture)} HostName: {Dns.GetHostName()} Path: {HttpContext.Request.Path}";
            return Ok(message);
        }

        #endregion

        #region private methods

        private Repository<User> GetRepo(string table)
        {
            return new Repository<User>(_context);
        }

        #endregion

    }
}