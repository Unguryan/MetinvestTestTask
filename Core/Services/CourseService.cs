using Core.Extensions;
using Core.Helpers;
using Interfaces.Context;
using Interfaces.Context.Models;
using Interfaces.Models;
using Interfaces.Services;
using Interfaces.ViewModels.Course;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CourseService : ICourseService
    {
        
        private readonly StudentsContext _context;

        public CourseService(StudentsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ICourse>> GetAllCourses()
        {
            var res = new List<ICourse>();

            await foreach (var item in _context.Courses.AsAsyncEnumerable())
            {
                res.Add(item.ToCourse());
            }

            return res;
        }

        public async Task<ICourse> GetCourseById(IGetCourseByIdViewModel model)
        {
            await foreach (var item in _context.Courses.Include(x => x.Students).AsAsyncEnumerable())
            {
                if (item.Id == model.IdCourse)
                {
                    return item.ToCourse();
                }
            }

            return null;
        }

        public async Task<IEnumerable<ICourse>> GetCourseByStudentId(IGetCourseByStudentIdViewModel model)
        {
            var res = new List<ICourse>();

            await foreach (var item in _context.Courses.Include(x => x.Students).AsAsyncEnumerable())
            {
                if (item.Students.Any(x => x.StudentId == model.IdStudent))
                {
                    res.Add(item.ToCourse());
                }
            }

            return res;
        }

        public async Task<ICourse> AddCourse(IAddCourseViewModel model)
        {
            if(!DateHelper.ValidateDates(model.StartDate, model.EndDate))
            {
                return null;
            }

            var c = new CourseDB()
            {
                StartDate = model.StartDate,
                EndDate = model.EndDate
            };

            var res = await _context.Courses.AddAsync(c);
            await _context.SaveChangesAsync();
            return res.Entity.ToCourse();
        }
    }
}
