using System.Linq;
using Fortes.Assess.Domain;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Fortes.Assess.Data.Repositories.ConnectedData
{
    class ConnectedData
    {
        private readonly AssessDbContext _context;

        public ConnectedData(AssessDbContext context)
        {
            _context = context;
        }

        public LocalView<Assessment> AssessmentsListInMemory()
        {
            if (_context.Assessments.Local.Count == 0)
            {
                _context.Assessments.ToList();
            }

            return _context.Assessments.Local;
        }
    }
}
