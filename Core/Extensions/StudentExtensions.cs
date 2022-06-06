using Core.Helpers;
using Interfaces.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Extensions
{
    public static class StudentExtensions
    {
        public static bool TryAddVacation(this KeyValuePair<ICourse, IDictionary<DateTime, DateTime>> course, 
                                          DateTime startVacationDate,
                                          DateTime endVacationDate)
        {
            if (DateHelper.ValidateDates(startVacationDate, endVacationDate) &&
               startVacationDate >= course.Key.StartDate &&
               startVacationDate <= course.Key.EndDate &&
               !course.Value.Any(v => (v.Key <= startVacationDate &&
                                    v.Value >= startVacationDate) ||
                                   (v.Key <= endVacationDate &&
                                    v.Value >= endVacationDate)))
            {
                course.Value.Add(startVacationDate, endVacationDate);
                var res = course.Value.OrderBy(v => v.Key).ToDictionary(x => x.Key, x => x.Value);
                course.Value.Clear();
                foreach (var item in res)
                {
                    course.Value.Add(item.Key, item.Value);
                }

                //course.EndDate.Add(endVacationDate - startVacationDate);
                return true;
            }

            return false;
        }
    }
}
