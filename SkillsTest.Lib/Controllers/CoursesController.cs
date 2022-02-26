using University.API.Services;

namespace University.API.Controllers
{
    public class CoursesController
    {
        private readonly ICourseAPI _courseAPI;

        public CoursesController(ICourseAPI courseAPI)
        {
            _courseAPI = courseAPI;
        }
    }
}
