using Interfaces.Models;
using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class Course : ICourse
    {

        public int Id { get; }

        public int IdStudent { get; }

        public DateTime StartDate { get; }

        public DateTime EndDate { get; set; }

        public IDictionary<DateTime, DateTime> Vacations { get; }

    }
}
