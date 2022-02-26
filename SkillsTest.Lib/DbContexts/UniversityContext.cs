using Microsoft.EntityFrameworkCore;
using University.Admin.Entities;

namespace University.Admin.DbContexts
{
    public class UniversityContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public UniversityContext(DbContextOptions options) : base(options)
        {
            // Nothing to do here
        }
    }
}
