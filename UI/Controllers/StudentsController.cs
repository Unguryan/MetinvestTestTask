using Interfaces.Models;
using Interfaces.Services;
using Interfaces.ViewModels.Student;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

            if (res != null && res.Id != 0)
            {
                return View("Index", await _studentService.GetAllStudents());
            }

            return View("_Error", "Error");
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

            var c = new List<ICourse>();
            foreach (var item in allCourses)
            {
                if(!studentCourses.Any(x => x.Id == item.Id))
                {
                    c.Add(item);
                }  
            }

            var model = new AddCourseToStudentModel()
            {
                Student = student,
                Courses = c
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

            if (res)
            {
                return View("Index", await _studentService.GetAllStudents());
            }

            return View("_Error", "Error");
        }

        [HttpGet("AddVacationToCourseView")]
        public async Task<IActionResult> AddVacationToCourseView(string id, string studentId)
        {
            int.TryParse(id, out int resId);
            int.TryParse(studentId, out int resStudentId);

            var model = new AddVacationToStudentCourseViewModel() { IdCourse = resId, IdStudent = resStudentId,
                                                                    StartVacationDate = DateTime.Now, EndVacationDate = DateTime.Now};

            return View("_AddVacationToStudentCourseView", model);
        }


        [HttpPost("AddVacationToStudentCoursePostAction")]
        public async Task<IActionResult> AddVacationToStudentCoursePostAction(AddVacationToStudentCourseViewModel model)
        {
            //int.TryParse(id, out int resId);
            //int.TryParse(studentId, out int resStudentId);

            //var model = new AddVacationToStudentCourseViewModel() { IdCourse = resId, IdStudent = resStudentId };

            var res = await _studentService.AddVacationToStudentCourse(model);
            if (res)
            {
                return Redirect($"GetStudentCourses/?id={model.IdStudent}");
            }

            return View("_Error", "Error");
        }
        
    }
}
