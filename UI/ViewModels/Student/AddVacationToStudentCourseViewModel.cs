using Interfaces.ViewModels.Student;
using System;

namespace UI.ViewModels.Student
{
    public class AddVacationToStudentCourseViewModel : IAddVacationToStudentCourseViewModel
    {
        
        public int IdStudent { get; }

        public int IdCourse { get; }

        public DateTime StartVacationDate { get; }

        public DateTime EndVacationDate { get; }

    }
}
