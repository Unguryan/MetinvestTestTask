using Interfaces.Models;
using System;
using System.Collections.Generic;

namespace Interfaces.Context.Models
{
    public class CourseDB : ICourse
    {

        public int Id { get; set; }

        public int IdStudent { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public IDictionary<DateTime, DateTime> Vacations { get; set; }

    }
}
