using Core.Extensions;
using Core.Helpers;
using Interfaces.Context;
using Interfaces.Context.Models;
using Interfaces.Models;
using Interfaces.ViewModels.Course;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces.Services
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
            return await _context.Courses.ToListAsync();
        }

        public async Task<IEnumerable<ICourse>> GetCourseByStudentId(IGetCourseByStudentIdViewModel model)
        {
            var res = new List<ICourse>();

            await foreach (var item in _context.Courses.AsAsyncEnumerable())
            {
                if (item.IdStudent == model.IdStudent)
                {
                    res.Add(item);
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
                IdStudent = model.IdStudent,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Vacations = new Dictionary<DateTime, DateTime>()
            };

            var res = await _context.Courses.AddAsync(c);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<bool> AddVacationToCourse(IAddVacationToCourseViewModel model)
        {
            var c = await _context.Courses.FirstOrDefaultAsync(p => p.Id == model.IdCourse);

            var res = c.TryAddVacation(model.StartVacationDate, model.EndVacationDate);
            if (res)
            {
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> RemoveCourseById(IRemoveCourseByIdViewModel model)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(p => p.Id == model.IdCourse);

            if (course == null)
            {
                return false;
            }

            var res = _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
