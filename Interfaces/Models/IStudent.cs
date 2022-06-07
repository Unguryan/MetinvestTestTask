using System;
using System.Collections.Generic;

namespace Interfaces.Models
{
    public interface IStudent
    {

        int Id { get; }

        string FullName { get; }

        string EmailAdress { get; }

        //idCourse - Vacations
        IDictionary<int, IDictionary<DateTime, DateTime>> Courses { get; }

    }
}
