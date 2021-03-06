using System;
using System.Collections.Generic;

namespace Interfaces.Context.Models
{
    public class StudentDB
    {

        public int Id { get; set; }

        public string FullName { get; set; }

        public string EmailAdress { get; set; }

        public IList<CourseStudentDB> Courses { get; set; }

        public Dictionary<int, Dictionary<DateTime, DateTime>> Vacations { get; set; }

    }
}
