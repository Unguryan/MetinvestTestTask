using Interfaces.Models;
using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class Course : ICourse
    {

        public Course(int id, DateTime startDate, DateTime endDate, List<int> students)
        {
            Id = id;
            StartDate = startDate;
            EndDate = endDate;
            Students = students;
        }

        public int Id { get; }

        public DateTime StartDate { get; }

        public DateTime EndDate { get; set; }

        public IList<int> Students { get; }

        //public IDictionary<DateTime, DateTime> Vacations { get; }

    }
}
