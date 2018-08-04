using System;
using System.Collections.Generic;
using System.Linq;
using Fortes.Assess.Data;
using Fortes.Assess.Domain;
using Microsoft.EntityFrameworkCore;

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
                Id = "Senior_Level",
                Name = "Senior_Level"
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
                Id = "Junior_Level",
                Name = "Junior Level",
                Questions = new List<Question>()
                {
                    new Question()
                    {
                        Id = "Level-Question1",
                        Description = "Question from Level 2",
                    },
                   new Question()
                    {
                        Id = "Level-Question2",
                        Description = "Question from Level 2",
                    }
                }
            };
            _context.Levels.Add(level);
            _context.SaveChanges();
        }

        private static void InsertOneToOne()
        {
            var assessment = new Assessment()
            {
                Id = "CUC-101",
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
                AssessmentId = "CUC-101",
                QuestionId = "Level-Question1"
            };
            _context.AssessmentQuestion.Add(aq);
            _context.SaveChanges();
        }


    }
}
