using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UI.ViewModels.Student;

namespace UI.Controllers
{
    [Route("[controller]")]
    public class StudentsController : Controller
    {

        private readonly ICourseService _courseService;

        private readonly IStudentService _studentService;

        public StudentsController(ICourseService courseService, IStudentService studentService)
        {
            _courseService = courseService;
            _studentService = studentService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _studentService.GetAllStudents());
        }

        [HttpGet("/{idStudent}")]
        public async Task<IActionResult> Index(int idStudent)
        {
            return View(await _studentService.GetStudentById(new GetStudentByIdViewModel() { IdStudent = idStudent }));
        }

        [HttpGet("AddStudentView")]
        public async Task<IActionResult> AddStudentView()
        {
            return View("_AddStudentView");
        }

        [HttpPost("AddCoursePostAction")]
        public async Task<IActionResult> AddStudentPostAction(AddStudentViewModel student)
        {
            var res = await _studentService.AddStudent(student);

            return View("Index", await _studentService.GetAllStudents());
        }
    }
}
