using System;
using System.Collections.Generic;

namespace Interfaces.Context.Models
{
    public class CourseDB 
    {

        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public IList<CourseStudentDB> Students { get; set; }

        //public IDictionary<DateTime, DateTime> Vacations { get; set; }

    }
}
