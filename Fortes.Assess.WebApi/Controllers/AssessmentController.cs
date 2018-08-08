using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Fortes.Assess.Data.Repositories.DisconnectedData;
using Fortes.Assess.Domain;

namespace Fortes.Assess.WebApi.Controllers
{
    [Route("api/[controller]")]
#if NETCOREAPP2_1
    [ApiController]
#endif
    public class AssessmentController : ControllerBase
    {
        private readonly DisconnectedData _repo;

        public AssessmentController(DisconnectedData repo)
        {
            _repo = repo;
        }

        [HttpGet("/user/{id}")]
        public IEnumerable<KeyValuePair<int, string>> GetAllFromUser(int userId)
        {
            return _repo.GeAssessmentIds(userId);
        }

        [HttpGet("{id}")]
        public Assessment Get(int id)
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
        public void DeleteAssessment(int id)
        {
            _repo.DeleteAssessment(id);
        }

    }
}