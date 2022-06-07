using Interfaces.Models;
using System.Collections.Generic;

namespace UI.Models
{
    public class AddCourseToStudentModel
    {
        public IStudent Student { get; set; }

        public IList<ICourse> Courses { get; set; }
    }
}
