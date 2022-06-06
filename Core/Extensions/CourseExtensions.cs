using Core.Helpers;
using Interfaces.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Linq;

namespace Core.Extensions
{
    public static class CourseExtensions
    {
        public static bool TryAddVacation(this ICourse course, DateTime startVacationDate, DateTime endVacationDate)
        {
            if(DateHelper.ValidateDates(startVacationDate, endVacationDate) &&
               startVacationDate >= course.StartDate && 
               startVacationDate <= course.EndDate &&
               !course.Vacations.Any(v => (v.Key <= startVacationDate &&
                                           v.Value >= startVacationDate) ||
                                          (v.Key <= endVacationDate &&
                                           v.Value >= endVacationDate)))
            {
                course.Vacations.Add(startVacationDate, endVacationDate);
                var res = course.Vacations.OrderBy(v => v.Key).ToDictionary(x => x.Key, x => x.Value);
                course.Vacations.Clear();
                foreach (var item in res)
                {
                    course.Vacations.Add(item.Key, item.Value);
                }

                course.EndDate.Add(endVacationDate - startVacationDate);
                return true;
            }

            return false;
        }
    }
}
