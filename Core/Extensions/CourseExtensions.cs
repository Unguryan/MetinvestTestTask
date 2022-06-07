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

            //var vacations = studentDB.Vacations.First(x => x.Key == course.Id).Value;
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
                    //var s = courseDB.Students.First(x => x.CourseId == item.CourseId).Student;
                    //if (s != null)
                    //{
                    //    var dictionary = new Dictionary<int, IDictionary<DateTime, DateTime>>();

                    //    for (int i = 0; i < s.Vacations.Count; i++)
                    //    {
                    //        var temp = new Course(s.Courses[i].Course.Id,
                    //                              s.Courses[i].Course.StartDate,
                    //                              s.Courses[i].Course.EndDate,
                    //                              stud);

                    //        dictionary.Add(temp, s.Vacations[s.Courses[i].CourseId]);
                    //    }
                    //    stud.Add(new Student(s.Id, s.FullName, s.EmailAdress, dictionary));
                    //}
                }
            }

            return new Course(courseDB.Id, 
                              courseDB.StartDate,
                              courseDB.EndDate,
                              stud);
        }
    }
}
