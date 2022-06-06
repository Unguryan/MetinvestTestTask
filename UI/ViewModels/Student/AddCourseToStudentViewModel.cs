using Interfaces.Models;
using Interfaces.ViewModels.Student;

namespace UI.ViewModels.Student
{
    public class AddCourseToStudentViewModel : IAddCourseToStudentViewModel
    {

        public int IdStudent { get; }

        public ICourse Course { get; }

    }
}
