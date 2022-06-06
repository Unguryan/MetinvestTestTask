using System;

namespace Interfaces.ViewModels.Student
{
    public interface IAddVacationToStudentCourseViewModel
    {

        int IdStudent { get; }

        int IdCourse { get; }

        DateTime StartVacationDate { get; }

        DateTime EndVacationDate { get; }

    }
}
