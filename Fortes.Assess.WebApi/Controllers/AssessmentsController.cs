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

    public class AssessmentsController : BaseController
    {
        #region constructor

        private readonly IRepository<Assessment> _repo;
        private readonly ILogger _logger;

        #endregion

        #region Public Methods

        public AssessmentsController(IRepository<Assessment> repo, ILogger<AssessmentsController> logger, IHttpContextAccessor context)
        {
            _logger = logger ?? throw new ArgumentNullException($"logger is not defined!");
            var httpcontext = context ?? throw new ArgumentNullException($"dbcontext is not defined");
            _repo = repo ?? throw new ArgumentException($"Assessment repository is not defined!");

            _logger.LogInformation($"Host: {httpcontext.HttpContext.Request.Host} IsAuthenticated: {httpcontext.HttpContext.User.Identity.IsAuthenticated}");
        }

        /// <summary>
        /// GET: api/assessments
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repo.GetAllAsync());
        }

        /// <summary>
        /// GET: api/Assessments/id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Get(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid id {id}");
                return BadRequest();
            }
            var assessment = await _repo.GetByKeyAsync(id);
            if (assessment == null)
            {
                _logger.LogError($"Get: assessment {id} not found");
                return NotFound();
            }
            return Ok(assessment);
        }

        /// <summary>
        /// POST: api/assessments
        /// </summary>
        /// <param name="assessment"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] Assessment assessment)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Post: BadRequest: - {ModelState}");
                return BadRequest(ModelState);
            }
            await _repo.ModifyAsync(assessment);

            return CreatedAtAction("Post", new { id = assessment.Id }, assessment);
        }

        /// <summary>
        /// PUT: api/assessments/id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="assessment"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Assessment assessment)
        {
            if (!ModelState.IsValid || id != assessment.Id)
            {
                _logger.LogError($"Put: BadRequest: - {ModelState}");
                return BadRequest(ModelState);
            }

            var updated = await _repo.ModifyAsync(assessment);
            if (updated == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        
        /// <summary>
        /// DELETE: api/assessments/id
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