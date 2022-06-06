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
            return await _context.Students.ToListAsync();
        }

        public async Task<IStudent> GetStudentById(IGetStudentByIdViewModel model)
        {
            return await _context.Students.Include(s => s.Courses).FirstOrDefaultAsync(p => p.Id == model.IdStudent);
        }

        public async Task<IStudent> AddStudent(IAddStudentViewModel model)
        {
            var s = new StudentDB()
            {
                FullName = model.FullName,
                EmailAdress = model.EmailAdress,
                Courses = new Dictionary<ICourse, IDictionary<DateTime, DateTime>>()
            };

            var res = await _context.Students.AddAsync(s);
            await _context.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<bool> AddCourseToStudent(IAddCourseToStudentViewModel model)
        {
            var user = await _context.Students.Include(s => s.Courses).FirstOrDefaultAsync(p => p.Id == model.IdStudent);

            if (user == null)
            {
                return false;
            }

            var res = user.Courses.TryAddNewCource(model.Course);

            if (res)
            {
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> AddVacationToStudentCourse(IAddVacationToStudentCourseViewModel model)
        {
            var user = await _context.Students.Include(s => s.Courses).FirstOrDefaultAsync(p => p.Id == model.IdStudent);

            if (user == null)
            {
                return false;
            }

            var c = user.Courses.FirstOrDefault(p => p.Key.Id == model.IdCourse);

            if (c.Key == null)
            {
                return false;
            }

            var res = c.TryAddVacation(model.StartVacationDate, model.EndVacationDate);
            if (res)
            {
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> RemoveStudentById(IRemoveStudentByIdViewModel model)
        {
            var user = await _context.Students.FirstOrDefaultAsync(p => p.Id == model.IdStudent);

            if (user == null)
            {
                return false;
            }

            var res = _context.Students.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
