using System;

namespace Interfaces.ViewModels.Course
{
    public interface IAddCourseViewModel
    {

        int IdUser { get; }

        DateTime StartDate { get; }

        DateTime EndDate { get; }

    }
}
