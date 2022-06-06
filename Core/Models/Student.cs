using Interfaces.Models;
using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class Student : IStudent
    {

        public int Id { get; }

        public string FullName { get; }

        public string EmailAdress { get; }

        public IDictionary<ICourse, IDictionary<DateTime, DateTime>> Courses { get; }

    }
}
