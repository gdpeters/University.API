using Microsoft.AspNetCore.Mvc;
using University.API.Services;

namespace University.Admin.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentAPI _studentAPI;

        public StudentsController(IStudentAPI studentAPI)
        {
            _studentAPI = studentAPI;
        }

        /// <summary>
        /// Search for a student by student id
        /// </summary>
        /// <param name="studentId">Student Id</param>
        /// <returns>The student with the specified id</returns>
        [HttpGet]
        public IActionResult GetStudent(int studentId)
        {
            var student = _studentAPI.GetStudent(studentId);   

            if (student == null)
                return NotFound();  

            return Ok(student);
        }

        /// <summary>
        /// Retrieve a specified page of students in alphabetical order by last name
        /// </summary>
        /// <param name="page">The page to retrieve. The first page is 0. The default is 0.</param>
        /// <param name="pageSize">The number of students to view on one page. The default will return all students.</param>
        /// <returns>Students on a specified page</returns>
        public IActionResult GetStudents(int? page, int? pageSize)
        {
            var students = _studentAPI.GetStudents(page, pageSize);

            if (students == null)
                return NotFound();

            return Ok(students);
        }


        /// <summary>
        /// Retrieve all students with a specified last name
        /// </summary>
        /// <param name="lastName">The student's last name</param>
        /// <returns>Students having the specified last name</returns>
        public IActionResult GetStudents(string lastName)
        {
            var students = _studentAPI.GetStudents(lastName);

            if (students == null)
                return NotFound();

            return Ok(students);
        }

        /// <summary>
        /// Retrieve all students enrolled in a specified course
        /// </summary>
        /// <param name="courseId">Course Id</param>
        /// <returns>Students enrolled in the specified course</returns>
        public IActionResult GetStudentsInCourse(int courseId)
        {
            var students = _studentAPI.GetStudentsInCourse(courseId);

            if (students == null)
                return NotFound();

            return Ok(students);
        }
    }
}
