using Core.Extensions;
using Interfaces.Context;
using Interfaces.Context.Models;
using Interfaces.Models;
using Interfaces.Services;
using Interfaces.ViewModels.Student;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class StudentService : IStudentService
    {

        private readonly StudentsContext _context;

        public StudentService(StudentsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IStudent>> GetAllStudents()
        {
            var res = new List<IStudent>();

            await foreach (var item in _context.Students.Include(x => x.Courses).AsAsyncEnumerable())
            {
                res.Add(item.ToStudent());
            }

            return res;
        }

        public async Task<IStudent> GetStudentById(IGetStudentByIdViewModel model)
        {
            var res = new List<IStudent>();

            await foreach (var item in _context.Students.Include(x => x.Courses).AsAsyncEnumerable())
            {
                if (item.Id == model.IdStudent)
                    return item.ToStudent();
            }

            return null;

            //return await _context.Students.Include(s => s.Courses).FirstOrDefaultAsync().ToStudent();
        }

        public async Task<IStudent> AddStudent(IAddStudentViewModel model)
        {
            var s = new StudentDB()
            {
                FullName = model.FullName,
                EmailAdress = model.EmailAdress,
                Vacations = new Dictionary<int, IDictionary<DateTime, DateTime>>()
                //Courses = new List<CourseStudentDB>()
            };

            var res = await _context.Students.AddAsync(s);
            await _context.SaveChangesAsync();
            return res.Entity.ToStudent();
        }

        public async Task<bool> AddCourseToStudent(IAddCourseToStudentViewModel model)
        {
            var student = await _context.Students.Include(s => s.Courses).FirstOrDefaultAsync(p => p.Id == model.IdStudent);

            if (student == null)
            {
                return false;
            }

            var res = student.TryAddNewCource(model.Course);

            if (res)
            {
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> AddVacationToStudentCourse(IAddVacationToStudentCourseViewModel model)
        {
            var student = await _context.Students.Include(s => s.Courses).FirstOrDefaultAsync(p => p.Id == model.IdStudent);

            if (student == null)
            {
                return false;
            }

            var c = student.Courses.FirstOrDefault(p => p.CourseId == model.IdCourse);

            if (c == null)
            {
                return false;
            }

            var res = student.TryAddVacation(c.CourseId, model.StartVacationDate, model.EndVacationDate);
            if (res)
            {
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> RemoveStudentById(IRemoveStudentByIdViewModel model)
        {
            var student = await _context.Students.FirstOrDefaultAsync(p => p.Id == model.IdStudent);

            if (student == null)
            {
                return false;
            }

            var res = _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
