using Core.Models;
using Interfaces.Context.Models;
using Interfaces.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Extensions
{
    public static class CourseExtensions
    {
        public static bool TryAddNewCource(this StudentDB studentDB, ICourse course)
        {
            if (studentDB.Vacations == null || studentDB.Vacations.Any(x => x.Key == course.Id))
            {
                return false;
            }

            var courses = studentDB.Courses.Select(x => x.Course);
            if (!courses.Any(c => (c.StartDate <= course.StartDate &&
                                   c.EndDate >= course.StartDate) ||
                                  (c.StartDate <= course.EndDate &&
                                   c.EndDate >= course.EndDate)))
            {
                studentDB.Courses.Add(new CourseStudentDB() { CourseId = course.Id, StudentId = studentDB.Id});
                studentDB.Vacations.Add(course.Id, new Dictionary<DateTime, DateTime>());
                return true;
            }

            return false;
        }

        public static ICourse ToCourse(this CourseDB courseDB)
        {
            var stud = new List<int>();

            if(courseDB.Students != null)
            {
                foreach (var item in courseDB?.Students)
                {
                    stud.Add(item.StudentId);
                }
            }

            return new Course(courseDB.Id, 
                              courseDB.StartDate,
                              courseDB.EndDate,
                              stud);
        }
    }
}
