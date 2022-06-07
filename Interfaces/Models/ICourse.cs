using System;
using System.Collections.Generic;

namespace Interfaces.Models
{
    public interface ICourse
    {

        int Id { get; }

        DateTime StartDate { get; }

        DateTime EndDate { get; set; }

        IList<IStudent> Students { get; }

        //IDictionary<DateTime, DateTime> Vacations { get; }

    }
}
