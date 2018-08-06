using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Fortes.Assess.Data.Repositories.DisconnectedData;
using Fortes.Assess.Domain;

namespace Fortes.Assess.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessmentController : ControllerBase
    {
        private readonly DisconnectedData _repo;

        public AssessmentController(DisconnectedData repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<string> GetAllFromUser()
        {
            return _repo.GeAssessmentIds();
        }

        [HttpGet("{id}")]
        public Assessment Get(string id)
        {
            return _repo.GetAssessment(id);
        }

        [HttpPost]
        public void AddAssessment([FromBody] Assessment assessment)
        {
            _repo.SaveAssessment(assessment, true);
        }

        [HttpPut("{id}")]
        public void ModifyAssessment(string id, [FromBody] Assessment assessment)
        {
            _repo.SaveAssessment(assessment, false);
        }

        [HttpDelete("{id}")]
        public void DeleteAssessment(string id)
        {
            _repo.DeleteAssessment(id);
        }

    }
}