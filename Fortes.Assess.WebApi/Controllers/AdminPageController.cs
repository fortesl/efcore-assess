﻿namespace Fortes.Assess.WebApi.Controllers
{
    #region usings

    using System;
    using Fortes.Assess.Data.Repositories;
    using Fortes.Assess.Domain;
    using Microsoft.AspNetCore.Mvc;
    using System.Globalization;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;

    #endregion

    public class AdminPageController : BaseController
    {
        #region constructor

        private readonly IRepository<AdminPage> _repo;
        private readonly ILogger _logger;
        private readonly IHttpContextAccessor _context;

        #endregion

        #region Public Methods

        public AdminPageController(IRepository<AdminPage> repo, ILogger<AdminPageController> logger, IHttpContextAccessor context)
        {
            _logger = logger ?? throw new ArgumentNullException("logger is not defined!");
            _context = context ?? throw new ArgumentNullException("dbcontext is not defined");
            _repo = repo ?? throw new ArgumentException("repository is not defined!");

            _logger.LogInformation($"Host: {_context.HttpContext.Request.Host} IsAuthenticated: {_context.HttpContext.User.Identity.IsAuthenticated}");
        }

        /// <summary>
        /// GET: api/AdminPage
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _repo.GetAllAsync());
        }

        /// <summary>
        /// GET: api/AdminPage/id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Get(int id)
        {
            var page = await _repo.GetByKeyAsync(id);
            if (page == null)
            {
                _logger.LogWarning($"Get: id {id} not found");
                return NotFound();
            }
            return Ok(page);
        }

        /// <summary>
        /// POST: api/AdminPage
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] AdminPage page)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning($"Post: BadRequest: - {ModelState}");
                return BadRequest(ModelState);
            }
            await _repo.InsertAsync(page);

            return CreatedAtAction("Post", new { id = page.Id }, page);
        }

        /// <summary>
        /// PUT: api/AdminPage/id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] AdminPage page)
        {
            if (!ModelState.IsValid || id != page.Id)
            {
                _logger.LogWarning($"Put: BadRequest: - {ModelState}");
                return BadRequest(ModelState);
            }

            var updated = await _repo.UpdateAsync(id, page);
            if (updated == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        
        /// <summary>
        /// DELETE: api/AdminPage/id
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