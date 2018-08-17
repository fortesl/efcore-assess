using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fortes.Assess.Data;
using Fortes.Assess.Domain;

namespace Fortes.Assess.WebApi.Controllers
{
    [Route("api/[controller]")]
#if !NETCOREAPP2_0
    [ApiController]
#endif
    public class AssessmentsController : ControllerBase
    {
        private readonly AssessDbContext _context;

        public AssessmentsController(AssessDbContext context)
        {
            _context = context;
        }

        // GET: api/Assessments
        [HttpGet]
        public IEnumerable<Assessment> GetAssessments()
        {
            return _context.Assessments;
        }

        // GET: api/Assessments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssessment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assessment = await _context.Assessments.FindAsync(id);

            if (assessment == null)
            {
                return NotFound();
            }

            return Ok(assessment);
        }

        // PUT: api/Assessments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssessment([FromRoute] int id, [FromBody] Assessment assessment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assessment.Id)
            {
                return BadRequest();
            }

            _context.Entry(assessment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssessmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Assessments
        [HttpPost]
        public async Task<IActionResult> PostAssessment([FromBody] Assessment assessment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Assessments.Add(assessment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssessment", new { id = assessment.Id }, assessment);
        }

        // DELETE: api/Assessments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssessment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var assessment = await _context.Assessments.FindAsync(id);
            if (assessment == null)
            {
                return NotFound();
            }

            _context.Assessments.Remove(assessment);
            await _context.SaveChangesAsync();

            return Ok(assessment);
        }

        private bool AssessmentExists(int id)
        {
            return _context.Assessments.Any(e => e.Id == id);
        }
    }
}