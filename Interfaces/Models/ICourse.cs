using System;

namespace Interfaces.Models
{
    public interface ICourse
    {

        int Id { get; }

        int IdUser { get; }

        DateTime StartDate { get; }

        DateTime EndDate { get; }

    }
}
