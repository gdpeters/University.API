using System.Linq;
using University.Admin.DbContexts;
using University.Admin.Entities;

namespace University.API.Services
{
    public interface ICourseAPI
    {
        Course GetById(int id);
    }

    public class DbCourseAPI : ICourseAPI
    {
        public UniversityContext Db { get; set; }

        public Course GetById(int id)
        {
            return Db.Courses.Where(course => course.Id == id).SingleOrDefault();
        }
    }
}