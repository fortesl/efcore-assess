using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Fortes.Assess.Data;
using Fortes.Assess.Domain;

namespace Fortes.Assess.ConsoleApp
{
    class Program
    {
        private static AssessDbContext _context = new AssessDbContext();

        static void Main(string[] args)
        {
            _context.Database.EnsureCreated();
            InsertAssessment();
        }

        private static void InsertLevel()
        {
            var level = new Level()
            {
                Id = "Senior_Level",
                Name = "Senior_Level"
            };
                _context.Levels.Add(level);
                _context.Levels.Remove(level);
                _context.SaveChanges();
        }

        private static void GetLevels()
        {
                var levels = _context.Levels.ToList();
                Console.WriteLine(levels);
        }

        private static void InsertAssessment()
        {
            var assessment = new Assessment()
            {
                Id = "CUC-101",
                Description = "County Jail",
                Questions = new List<AssessmentQuestion>()
                {
                    new AssessmentQuestion()
                    {
                        QuestionId = "Question1",
                        AssessmentId = "CUC-101"
                    }
                }
            };
            var question = new Question()
            {
                Id = "Question1",
                Description = "First CUC Question"
            };
  //          _context.Questions.Add(question);
            _context.Assessments.Add(assessment);
            _context.SaveChanges();
        }


    }
}
