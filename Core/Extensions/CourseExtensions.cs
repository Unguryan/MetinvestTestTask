using Interfaces.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Extensions
{
    public static class CourseExtensions
    {
        public static bool TryAddNewCource(this IDictionary<ICourse, IDictionary<DateTime, DateTime>> courses, ICourse course)
        {
            if (courses == null || !courses.Any() || courses.Any(x => x.Key.Id == course.Id))
            {
                return false;
            }

            if (!courses.Select(x => x.Key).Any(c => (c.StartDate <= course.StartDate &&
                                                      c.EndDate >= course.StartDate) ||
                                                     (c.StartDate <= course.EndDate &&
                                                      c.EndDate >= course.EndDate)))
            {
                courses.Add(course, new Dictionary<DateTime, DateTime>());
                return true;
            }

            return false;
        }
    }
}
