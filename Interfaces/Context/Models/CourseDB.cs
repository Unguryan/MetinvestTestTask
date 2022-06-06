using Interfaces.Models;
using System;

namespace Interfaces.Context.Models
{
    public class CourseDB : ICourse
    {

        public int Id { get; set; }

        public int IdUser { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

    }
}
