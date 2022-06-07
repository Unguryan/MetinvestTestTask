namespace Interfaces.Context.Models
{
    public class CourseStudentDB
    {
        public int StudentId { get; set; }

        public StudentDB Student { get; set; }

        public int CourseId { get; set; }

        public CourseDB Course { get; set; }
    }
}
