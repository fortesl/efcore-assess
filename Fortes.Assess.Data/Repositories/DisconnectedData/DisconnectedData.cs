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

        public List<string> GeAssessmentIds()
        {
            var assessments = _context.Assessments.OrderBy(a => a.LastModified)
                .Select(s => s.Id)
                .ToList();
            return assessments;
        }

        public Assessment GetAssessment(string id)
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

        public void DeleteAssessment(string id)
        {
            var assessment = _context.Assessments.Find(id);
            _context.Entry(assessment).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
