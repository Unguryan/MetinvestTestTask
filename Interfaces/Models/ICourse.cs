using System;
using System.Collections.Generic;

namespace Interfaces.Models
{
    public interface ICourse
    {

        int Id { get; }

        DateTime StartDate { get; }

        DateTime EndDate { get; set; }

        IList<int> Students { get; }

        //IDictionary<DateTime, DateTime> Vacations { get; }

    }
}
