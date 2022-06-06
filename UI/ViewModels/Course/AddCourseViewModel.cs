using Interfaces.ViewModels.Course;
using System;

namespace UI.ViewModels.Course
{
    public class AddCourseViewModel : IAddCourseViewModel
    {

        public int IdStudent { get; }

        public DateTime StartDate { get; }

        public DateTime EndDate { get; }

    }
}
