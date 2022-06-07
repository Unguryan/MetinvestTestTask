using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UI.ViewModels.Course;

namespace UI.Controllers
{
    [Route("[controller]")]
    public class CoursesController : Controller
    {
        
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _courseService.GetAllCourses());
        }

        [HttpGet("/{idStudent}")]
        public async Task<IActionResult> Index(int idStudent)
        {
            return View(await _courseService.GetCourseByStudentId(new GetCourseByStudentIdViewModel() { IdStudent = idStudent }));
        }


        [HttpGet("AddCourseView")]
        public async Task<IActionResult> AddCourseView()
        {
            return View("_AddCourseView");
        }

        [HttpPost("AddCoursePostAction")]
        public async Task<IActionResult> AddCoursePostAction(AddCourseViewModel course)
        {
            var res = await _courseService.AddCourse(course);

            return View("Index", await _courseService.GetAllCourses());
        }
    }
}
