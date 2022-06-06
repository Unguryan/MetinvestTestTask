using Interfaces.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Linq;

namespace Core.Extensions
{
    public static class StudentExtensions
    {
        public static bool TryAddNewCource(this IList<ICourse> courses, ICourse course)
        {
            if(courses == null || !courses.Any())
            {
                return false;
            }

            if (courses.Last().EndDate <= course.StartDate)
            {
                courses.Add(course);
                return true;
            }

            return false;
        }
    }
}
