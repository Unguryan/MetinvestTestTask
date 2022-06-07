using Interfaces.Models;
using Interfaces.ViewModels.Student;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IStudentService
    {

        Task<IEnumerable<IStudent>> GetAllStudents();

        Task<IEnumerable<IStudent>> GetStudentsByCourseId(IGetStudentsByCourseIdViewModel model);

        Task<IStudent> GetStudentById(IGetStudentByIdViewModel model);

        Task<IStudent> AddStudent(IAddStudentViewModel model);

        Task<bool> AddCourseToStudent(IAddCourseToStudentViewModel model);

        Task<bool> AddVacationToStudentCourse(IAddVacationToStudentCourseViewModel model);

    }
}
