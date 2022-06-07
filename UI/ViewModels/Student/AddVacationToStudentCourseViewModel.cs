using Interfaces.ViewModels.Student;
using System;

namespace UI.ViewModels.Student
{
    public class AddVacationToStudentCourseViewModel : IAddVacationToStudentCourseViewModel
    {
        
        public int IdStudent { get; set; }

        public int IdCourse { get; set; }

        public DateTime StartVacationDate { get; set; }

        public DateTime EndVacationDate { get; set; }

    }
}
