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
            //        GetLevels();
            //InsertOneToMany();
            // InsertOneToOne();
            InsertManyToMany();
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
