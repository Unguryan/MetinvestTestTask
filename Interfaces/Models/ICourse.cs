using System;
using System.Collections.Generic;

namespace Interfaces.Models
{
    public interface ICourse
    {

        int Id { get; }

        int IdStudent { get; }

        DateTime StartDate { get; }

        DateTime EndDate { get; set; }

        IDictionary<DateTime, DateTime> Vacations { get; }

    }
}
