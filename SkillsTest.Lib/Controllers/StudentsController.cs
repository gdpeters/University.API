using Microsoft.AspNetCore.Mvc;
using University.API.Services;

namespace University.Admin.Controllers
{
    public class StudentsController : ControllerBase
    {
        private readonly IStudentAPI _studentAPI;

        public StudentsController(IStudentAPI studentAPI)
        {
            _studentAPI = studentAPI;
        }

    }
}
