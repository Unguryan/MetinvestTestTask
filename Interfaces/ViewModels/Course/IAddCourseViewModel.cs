using System;

namespace Interfaces.ViewModels.Course
{
    public interface IAddCourseViewModel
    {

        int IdStudent { get; }

        DateTime StartDate { get; }

        DateTime EndDate { get; }

    }
}
