using Interfaces.Models;
using System;
using System.Collections.Generic;

namespace Core.Models
{
    public class Student : IStudent
    {
        public Student()
        {
        }

        public Student(int id, string fullName, string emailAdress, IDictionary<ICourse, IDictionary<DateTime, DateTime>> courses)
        {
            Id = id;
            FullName = fullName;
            EmailAdress = emailAdress;
            Courses = courses;
        }

        public int Id { get; }

        public string FullName { get; }

        public string EmailAdress { get; }

        public IDictionary<ICourse, IDictionary<DateTime, DateTime>> Courses { get; }

    }
}
