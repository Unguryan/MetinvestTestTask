using Interfaces.ViewModels.Student;

namespace UI.ViewModels.Student
{
    public class AddStudentViewModel : IAddStudentViewModel
    {

        public string FullName { get; set; }

        public string EmailAdress { get; set; }

    }
}
