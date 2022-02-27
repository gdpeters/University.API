using Microsoft.AspNetCore.Mvc;
using University.API.Services;

namespace University.API.Controllers
{
    [ApiController]
    [Route("api/courses")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseAPI _courseAPI;

        public CoursesController(ICourseAPI courseAPI)
        {
            _courseAPI = courseAPI;
        }

        /// <summary>
        /// Search for a course by id
        /// </summary>
        /// <param name="courseId">Course Id</param>
        /// <returns>The course with the specified id</returns>
        [HttpGet]
        public IActionResult GetCourse(int courseId)
        {
            var course = _courseAPI.GetCourse(courseId);

            if (course == null)
                return NotFound();

            return Ok(course);
        }


        /// <summary>
        /// Search for a course by name
        /// </summary>
        /// <param name="courseName">The name of the course</param>
        /// <returns>The course that matches the course name</returns>
        public IActionResult GetCourse(string courseName)
        {
            var course = _courseAPI.GetCourse(courseName);

            if (course == null)
                return NotFound();

            return Ok(course);
        }

        /// <summary>
        /// Retrieves a specified page of courses in alphabetical order
        /// </summary>
        /// <param name="page">The page to retrieve. The first page is 0 and the default value is 0.</param>
        /// <param name="pageSize">The number of courses to view on each page. The default will return all.</param>
        /// <returns>Courses on a specified page</returns>
        public IActionResult GetCourses(int? page, int? pageSize)
        {
            var courses = _courseAPI.GetCourses(page, pageSize);

            if (courses == null)
                return NotFound(); 

            return Ok(courses);
        }

    }
}
