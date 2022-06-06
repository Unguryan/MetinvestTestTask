using System;

namespace Interfaces.ViewModels.Course
{
    public interface IAddVacationToCourseViewModel
    {

        int IdCourse { get; }

        DateTime StartVacationDate { get; }

        DateTime EndVacationDate { get; }

    }
}
