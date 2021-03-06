using Core.Helpers;
using Core.Models;
using Interfaces.Context.Models;
using Interfaces.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Extensions
{
    public static class StudentExtensions
    {
        public static bool TryAddVacation(this StudentDB studentDB,
                                          int courseId,
                                          DateTime startVacationDate,
                                          DateTime endVacationDate)
        {
            var course = studentDB.Courses.FirstOrDefault(x => x.CourseId == courseId)?.Course;
            if (course == null) 
            {
                return false;
            }

            var vacations = studentDB.Vacations.FirstOrDefault(x => x.Key == courseId).Value;
            if (vacations == null)
            {
                return false;
            }

            if (DateHelper.ValidateDates(startVacationDate, endVacationDate) &&
               startVacationDate >= course.StartDate &&
               startVacationDate <= course.EndDate &&
               !vacations.Any(v => (v.Key <= startVacationDate &&
                                    v.Value >= startVacationDate) ||
                                   (v.Key <= endVacationDate &&
                                    v.Value >= endVacationDate) ||
                                    v.Key >= startVacationDate &&
                                    v.Value <= endVacationDate))
            {
                studentDB.Vacations[courseId].Add(startVacationDate, endVacationDate);
                var res = studentDB.Vacations[courseId].OrderBy(v => v.Key).ToDictionary(x => x.Key, x => x.Value);
                studentDB.Vacations[courseId].Clear();
                foreach (var item in res)
                {
                    studentDB.Vacations[courseId].Add(item.Key, item.Value);
                }

                return true;
            }

            return false;
        }

        public static IStudent ToStudent(this StudentDB studentDB)
        {
            var courses = new Dictionary<int, IDictionary<DateTime, DateTime>>();

            foreach (var item in studentDB?.Vacations)
            {
                courses.Add(item.Key, item.Value);
            }

            return new Student(studentDB.Id,
                               studentDB.FullName,
                               studentDB.EmailAdress,
                               courses);
        }
    }
}
