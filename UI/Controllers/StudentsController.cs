using Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using UI.Models;
using UI.ViewModels.Course;
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

        [HttpGet("GetStudentCourses")]
        public async Task<IActionResult> GetStudentCourses(string id)
        {
            int.TryParse(id, out int res);
            var student = await _studentService.GetStudentById(new GetStudentByIdViewModel() { IdStudent = res });
            var courses = await _courseService.GetCourseByStudentId(new GetCourseByStudentIdViewModel() { IdStudent = res });
            var model = new AddCourseToStudentModel()
            {
                Courses = courses.ToList(),
                Student = student
            };

            return View("../Courses/_StudentCoursesView", model);
        }

        [HttpGet("AddStudentView")]
        public async Task<IActionResult> AddStudentView()
        {
            return View("_AddStudentView");
        }

        [HttpPost("AddStudentPostAction")]
        public async Task<IActionResult> AddStudentPostAction(AddStudentViewModel student)
        {
            var res = await _studentService.AddStudent(student);

            return View("Index", await _studentService.GetAllStudents());
        }

        [HttpGet("AddCourseToStudentView")]
        public async Task<IActionResult> AddCourseToStudentView(string id)
        {
            int.TryParse(id, out int res);
            var student = await _studentService.GetStudentById(new GetStudentByIdViewModel() { IdStudent = res });

            if(student == null)
            {
                return null;
            }

            var allCourses = await _courseService.GetAllCourses();
            var studentCourses = await _courseService.GetCourseByStudentId(new GetCourseByStudentIdViewModel() { IdStudent = res });

            var model = new AddCourseToStudentModel()
            {
                Student = student,
                Courses = allCourses.Except(studentCourses).ToList()
            };

            return View("_AddCourseToStudentView", model);
        }

        [HttpGet("AddCourseToStudentPostAction")]
        public async Task<IActionResult> AddCourseToStudentPostAction(string id, string studentId)
        {
            int.TryParse(id, out int resId);
            int.TryParse(studentId, out int resStudentId);

            var res = await _studentService.AddCourseToStudent(new AddCourseToStudentViewModel()
            {
                Course = await _courseService.GetCourseById(new GetCourseByIdViewModel() { IdCourse = resId }),
                IdStudent = resStudentId
            });

            return View("Index", await _studentService.GetAllStudents());
        }
    }
}
