using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UI.ViewModels.Course;
using UI.ViewModels.Student;

namespace UI.Controllers
{
    [Route("[controller]")]
    public class CoursesController : Controller
    {
        
        private readonly ICourseService _courseService;

        private readonly IStudentService _studentService;

        public CoursesController(ICourseService courseService, IStudentService studentService)
        {
            _courseService = courseService;
            _studentService = studentService;
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

        [HttpGet("GetCourseStudents")]
        public async Task<IActionResult> GetCourseStudents(string id)
        {
            int.TryParse(id, out int res);
            return View("../Students/Index", await _studentService.GetStudentsByCourseId(new GetStudentsByCourseIdViewModel() { IdCourse = res }));
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
