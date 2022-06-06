using Interfaces.ViewModels.Student;

namespace UI.ViewModels.Student
{
    public class AddStudentViewModel : IAddStudentViewModel
    {

        public string FullName { get; }

        public string EmailAdress { get; }

    }
}
