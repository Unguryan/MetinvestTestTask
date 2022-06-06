using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("[controller]")]
    public class StudentController : Controller
    {

        private readonly ICourseService _courseService;

        private readonly IStudentService _studentService;

        public StudentController(ICourseService courseService, IStudentService studentService)
        {
            _courseService = courseService;
            _studentService = studentService;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
