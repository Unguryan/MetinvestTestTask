using System;

namespace UI.Models
{
    public class AddVacationToCourseModel
    {
        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public DateTime StartVacation { get; set; }

        public DateTime EndVacation { get; set; }
    }
}
