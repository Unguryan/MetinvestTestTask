using Interfaces.ViewModels.Course;
using System;

namespace UI.ViewModels.Course
{
    public class AddCourseViewModel : IAddCourseViewModel
    {

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

    }
}
