using Interfaces.ViewModels.Student;

namespace UI.ViewModels.Student
{
    public class GetStudentsByCourseIdViewModel : IGetStudentsByCourseIdViewModel
    {
        public int IdCourse { get; set; }
    }
}
