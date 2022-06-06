using System.Collections.Generic;

namespace Interfaces.Models
{
    public interface IStudent
    {

        int Id { get; }

        string FullName { get; }

        string EmailAdress { get; }

        IList<ICourse> Courses { get; }

    }
}
