using Interfaces.Models;

namespace Interfaces.ViewModels.Student
{
    public interface IAddCourseToStudentViewModel
    {

        int IdStudent { get; }

        ICourse Course { get; }

    }
}
