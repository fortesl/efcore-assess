using System.Collections.Generic;
using System.Linq;
using Fortes.Assess.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Fortes.Assess.Data.Repositories.DisconnectedData
{
    public class DisconnectedData
    {
        private readonly AssessDbContext _context;

        public DisconnectedData(AssessDbContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public IEnumerable<KeyValuePair<int, string>> GeAssessmentIds(int userId)
        {
            var assessments = _context.Assessments.OrderBy(a => a.LastModified)
                .Where(s => s.AssessmentUsers.Any(u => u.UserId == userId))
                .Select(s => new { s.Id, s.Name })
                .ToList();
            return (IEnumerable<KeyValuePair<int, string>>) assessments;
        }

        public Assessment GetAssessment(int id)
        {
            var assessment = _context.Assessments
                .Include(a => a.AdminPage)
                .Include(a => a.UserPage)
                .FirstOrDefault(a => a.Id == id);
            return assessment;
        }

        public void SaveAssessment(Assessment assessment, bool isNew)
        {
            _context.ChangeTracker.TrackGraph(assessment, e => ApplyState(e.Entry, isNew));
            _context.SaveChanges();
        }

        private static void ApplyState(EntityEntry entry, bool isNew)
        {
            entry.State = isNew ? EntityState.Added : EntityState.Modified;
        }

        public void DeleteAssessment(int id)
        {
            var assessment = _context.Assessments.Find(id);
            _context.Entry(assessment).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
