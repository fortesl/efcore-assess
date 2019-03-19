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

    public class QuestionsController : BaseController
    {
        #region constructor

        private readonly IRepository<Question> _repo;
        private readonly ILogger _logger;
        private readonly IHttpContextAccessor _context;

        #endregion

        #region Public Methods

        public QuestionsController(IRepository<Question> repo, ILogger<QuestionsController> logger, IHttpContextAccessor context)
        {
            _logger = logger ?? throw new ArgumentNullException($"logger is not defined!");
            _context = context ?? throw new ArgumentNullException($"dbcontext is not defined");
            _repo = repo ?? throw new ArgumentException($"Question repository is not defined!");

            _logger.LogInformation($"Host: {_context.HttpContext.Request.Host} IsAuthenticated: {_context.HttpContext.User.Identity.IsAuthenticated}");
        }

        /// <summary>
        /// GET: api/questions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repo.GetAllAsync());
        }

        /// <summary>
        /// GET: api/Questions/id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Get(int id)
        {
            var question = await _repo.GetByKeyAsync(id);
            if (question == null)
            {
                _logger.LogWarning($"Get: question {id} not found");
                return NotFound();
            }
            return Ok(question);
        }

        /// <summary>
        /// POST: api/questions
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] Question question)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning($"Post: BadRequest: - {ModelState}");
                return BadRequest(ModelState);
            }
            await _repo.ModifyAsync(question);

            return CreatedAtAction("Post", new { id = question.Id }, question);
        }

        /// <summary>
        /// PUT: api/questions/id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="question"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Question question)
        {
            if (!ModelState.IsValid || id != question.Id)
            {
                _logger.LogWarning($"Put: BadRequest: - {ModelState}");
                return BadRequest(ModelState);
            }

            var updated = await _repo.ModifyAsync(question);
            if (updated == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        
        /// <summary>
        /// DELETE: api/questions/id
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
                _logger.LogWarning($"Delete: BadRequest: - {ModelState}");
                return BadRequest(ModelState);
            }
            var deleted = await _repo.DeleteAsync(id);
            if (deleted == null)
            {
                _logger.LogWarning($"Delete: Not found {id}");
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