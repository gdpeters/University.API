using System.Collections.Generic;
using System.Linq;
using University.Admin.DbContexts;
using University.Admin.Entities;

namespace University.API.Services
{
    public interface ICourseAPI
    {
        Course GetCourse(int id);
        Course GetCourse(string courseName);
        IEnumerable<Course> GetCourses(int? page, int? pageSize);
    }

    public class DbCourseAPI : ICourseAPI
    {

        private readonly UniversityContext _universityContext;
        public DbCourseAPI(UniversityContext universityContext)
        {
            _universityContext = universityContext;
        }

        public Course GetCourse(int courseId)
        {
            return _universityContext.Courses.Where(course => course.Id == courseId).SingleOrDefault();
        }

        public Course GetCourse(string courseName)
        {
            return _universityContext.Courses.Where(course => course.Name.Equals(courseName)).SingleOrDefault();
        }

        public IEnumerable<Course> GetCourses(int? page, int? pageSize)
        {
            var pg = (page == null) ? 0 : page.Value;
            var ps = (pageSize == null) ? 10 : pageSize.Value;

            return _universityContext.Courses.OrderBy(course => course.Name).Skip(pg * ps).Take(ps);
        }
    }
}