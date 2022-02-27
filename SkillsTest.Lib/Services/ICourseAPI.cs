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

    public class CourseAPI : ICourseAPI
    {

        private readonly UniversityContext _universityContext;
        public CourseAPI(UniversityContext universityContext)
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
            if (page == null || pageSize == null)
            {
                return _universityContext.Courses.OrderBy(course => course.Name).ToList();
            }

            return _universityContext.Courses.OrderBy(course => course.Name).Skip(page.Value * pageSize.Value).Take(pageSize.Value).ToList();
        }
    }
}