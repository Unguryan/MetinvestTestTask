using Interfaces.Models;
using Interfaces.ViewModels.Course;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface ICourseService
    {

        Task<IEnumerable<ICourse>> GetAllCourses();

        Task<ICourse> GetCourseById(IGetCourseByIdViewModel model);

        Task<IEnumerable<ICourse>> GetCourseByStudentId(IGetCourseByStudentIdViewModel model);

        Task<ICourse> AddCourse(IAddCourseViewModel model);

    }
}
