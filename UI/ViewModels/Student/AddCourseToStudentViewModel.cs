using Interfaces.Models;
using Interfaces.ViewModels.Student;

namespace UI.ViewModels.Student
{
    public class AddCourseToStudentViewModel : IAddCourseToStudentViewModel
    {

        public int IdStudent { get; set; }

        public ICourse Course { get; set; }

    }
}
