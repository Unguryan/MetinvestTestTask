using Core.Extensions;
using Interfaces.Context;
using Interfaces.Context.Models;
using Interfaces.Models;
using Interfaces.ViewModels.Student;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interfaces.Services
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
                Courses = new List<ICourse>()
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

            //Add Transactions, Add Course here, to avoid not needed cource
            var res = user.Courses.TryAddNewCource(model.Course);

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
