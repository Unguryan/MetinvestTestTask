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

        public Student(int id, string fullName, string emailAdress, IDictionary<int, IDictionary<DateTime, DateTime>> courses)
        {
            Id = id;
            FullName = fullName;
            EmailAdress = emailAdress;
            Courses = courses;
        }

        public Student(int id, string fullName, string emailAdress)
        {
            Id = id;
            FullName = fullName;
            EmailAdress = emailAdress;
            Courses = new Dictionary<int, IDictionary<DateTime, DateTime>>();
        }

        public int Id { get; }

        public string FullName { get; }

        public string EmailAdress { get; }

        public IDictionary<int, IDictionary<DateTime, DateTime>> Courses { get; }

    }
}
