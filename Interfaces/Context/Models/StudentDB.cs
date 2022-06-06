using Interfaces.Models;
using System.Collections.Generic;

namespace Interfaces.Context.Models
{
    public class StudentDB : IStudent
    {

        public int Id { get; set; }

        public string FullName { get; set; }

        public string EmailAdress { get; set; }

        public IList<ICourse> Courses { get; set; }

    }
}
