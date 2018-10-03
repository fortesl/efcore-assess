using Fortes.Assess.Data;
using Fortes.Assess.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Fortes.Assess.ConsoleApp
{
    class Program
    {
        private const string _connectionString = "Server=(localdb)\\mssqllocaldb; Database=Assessment;Trusted_Connection=True;";

        private static readonly AssessDbContext _context = new AssessDbContext(_connectionString);

        static void Main(string[] args)
        {
            _context.Database.EnsureCreated();
            //        GetLevels();
 //           InsertOneToMany();
 //           InsertOneToOne();
 //          InsertManyToMany();
            GetRelatedData();
        }

        private static void InsertLevel()
        {
            var level = new Level()
            {
                Name = "Senior Level"
            };
            _context.Levels.Add(level);
            _context.SaveChanges();
        }


        private static void GetLevels()
        {
                var levels = _context.Levels.ToList();
                Console.WriteLine(levels);
        }

        private static void InsertOneToMany()
        {
            var level = new Level()
            {
                Name = "Junior Level",
            };
            _context.Levels.Add(level);
            _context.SaveChanges();
        }

        private static void InsertOneToOne()
        {
            var assessment = new Assessment()
            {
                Name = "CUC-101",
                Description = "Go directly to jail!",
                UserPage = new UserPage()
                {
                    Title = "User Page"
                }
            };
            assessment.AdminPage = new AdminPage()
            {
                Title = "Admin Page"
            };
            _context.Assessments.Add(assessment);
            _context.SaveChanges();
        }

        private static void GetRelatedData()
        {
            var assessment = _context.Assessments.Include(a => a.AdminPage).FirstOrDefault();
            Console.WriteLine(assessment);
            _context.Entry(assessment)
                .Collection(a => a.AssessmentQuestions)
                .Query()
                .Load();
            Console.WriteLine(assessment);
        }

        private static void InsertManyToMany()
        {
            var aq = new AssessmentQuestion()
            {
                AssessmentId = 1,
                QuestionId = 1
            };
            _context.Add(aq);
            _context.SaveChanges();
        }


    }
}
