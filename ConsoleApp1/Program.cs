using Fortes.Assess.Data;
using Fortes.Assess.Domain;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        private static readonly string _connectionString = "Server=(localdb)\\mssqllocaldb; Database=AssessmentWebApi;Trusted_Connection=True;MultipleActiveResultSets=true";
        private static readonly AssessDbContext _context = new AssessDbContext(_connectionString);

        static void Main(string[] args)
        {
            Console.Clear();
            Console.Write("Are you Sure you want to recreate the database? [N/Y]? ");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.WriteLine("\n\tRecreating database. Please wait ...");
                Seed();
            }
        }

        static private void Seed()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();

            //User
            var user = new User
            {
                Name = "Luis Fortes",
                FirstName = "Luis",
                LastName = "Fortes",
                Email = "lmlf100@gmailcom",
                UserRoles = new List<UserRole>
                {
                    new UserRole
                    {
                        Role = new Role
                        {
                            Name = "Admin"
                        }
                    }
                }
            };
            _context.Add(user);

            //Role
            var role2 = new Role
            {
                Name = "User"
            };
            var role3 = new Role
            {
                Name = "AssessmentUser"
            };
            _context.AddRange(role2, role3);


            _context.SaveChanges();
        }
    }
}
