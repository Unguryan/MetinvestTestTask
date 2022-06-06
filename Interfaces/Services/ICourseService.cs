using Interfaces.Models;
using Interfaces.ViewModels.Course;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface ICourseService
    {

        Task<IEnumerable<ICourse>> GetAllCourses();

        Task<IEnumerable<ICourse>> GetCourseByUserId(IGetCourseByUserIdViewModel model);

        Task<ICourse> AddCourse(IAddCourseViewModel model);

        Task<bool> AddVacationToCourse(IAddVacationToCourseViewModel model);

        Task<bool> RemoveCourseById(IRemoveCourseByIdViewModel model);

    }
}
