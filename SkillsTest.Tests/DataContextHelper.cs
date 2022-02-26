using Microsoft.EntityFrameworkCore;
using System.Linq;
using University.Admin.DbContexts;
using University.Admin.Entities;

namespace University.API.Tests
{
    internal class DataContextHelper
    {
        /// <summary>
        /// Returns an instance of the In-Memory db context for testing
        /// </summary>
        /// <returns></returns>
        public static UniversityContext GetMockDb(string name)
        {
            var options = new DbContextOptionsBuilder<UniversityContext>()
                .UseInMemoryDatabase(name)
                .Options;

            var db = new UniversityContext(options);

            // Seed the database

            if (!db.Courses.Any())
            {
                db.Courses.AddRange(new[]
                {
                    new Course { Id = 1, Name = "Advanced Basketweaving" },
                    new Course { Id = 2, Name = "Math for Liberal Arts Majors" },
                    new Course { Id = 3, Name = "The Cosmos: An Introduction" }
                });

                db.SaveChanges();
            }

            if (!db.Students.Any())
            {
                foreach (var iteration in Enumerable.Range(1, 100))
                {
                    db.Students.Add(new Student
                    {
                        Id = iteration,
                        FirstName = "Test",
                        LastName = $"Student {iteration}",
                        Courses = db.Courses.Where(course => iteration % course.Id == 0).ToList()
                    });
                }

                db.SaveChanges();
            }

            return db;
        }
    }
}