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

    public class StudentAPI : IStudentAPI
    {
        private readonly UniversityContext _universityContext;
        public StudentAPI(UniversityContext universityContext)
        {
            _universityContext = universityContext;
        }

        public Student GetStudent(int studentId)
        {
            return _universityContext.Students.Where(student => student.Id == studentId).SingleOrDefault();
        }

        public IEnumerable<Student> GetStudents(int? page, int? pageSize)
        {
            if (page == null || pageSize == null)
            {
                return _universityContext.Students.OrderBy(student => student.LastName).ToList();
            }

            return _universityContext.Students.OrderBy(student => student.LastName).Skip(page.Value * pageSize.Value).Take(pageSize.Value).ToList();
        }

        public IEnumerable<Student> GetStudents(string lastName)
        {
            return _universityContext.Students.Where(student => student.LastName.ToLower().Equals(lastName.ToLower())).ToList();
        }

        public IEnumerable<Student> GetStudentsInCourse(int courseId)
        {
            return _universityContext.Students.Where(student => student.Courses.Any(course => course.Id == courseId)).ToList();
        }
    }
}
