using System.Collections.Generic;
using System.Linq;
using University.Admin.DbContexts;
using University.Admin.Entities;

namespace University.API.Services
{
    public interface IStudentAPI
    {
        Student GetStudent(int studentId);
        IEnumerable<Student> GetStudents(int? page, int? pageSize);
        IEnumerable<Student> GetStudents(string lastName);
        IEnumerable<Student> GetStudentsInCourse(int courseId);
    }

    public class DbStudentAPI : IStudentAPI
    {
        private readonly UniversityContext _universityContext;
        public DbStudentAPI(UniversityContext universityContext)
        {
            _universityContext = universityContext;
        }

        public Student GetStudent(int studentId)
        {
            return _universityContext.Students.Where(student => student.Id == studentId).SingleOrDefault();
        }

        public IEnumerable<Student> GetStudents(int? page, int? pageSize)
        {
            var pg = (page == null) ? 0 : page.Value;
            var ps = (pageSize == null) ? 10 : pageSize.Value;

            return _universityContext.Students.OrderBy(student => student.LastName).Skip(pg * ps).Take(ps);

        }

        public IEnumerable<Student> GetStudents(string lastName)
        {
            return _universityContext.Students.Where(student => student.LastName.ToLower().Equals(lastName.ToLower()));
        }

        public IEnumerable<Student> GetStudentsInCourse(int courseId)
        {
            return _universityContext.Students.SelectMany(student => student.Courses, (student, course) => new { student, courseId })
                                           .Where(studentCourseIds => studentCourseIds.courseId == courseId)
                                           .Select(studentCourse => studentCourse.student)
                                           .ToList();
        }
    }
}
