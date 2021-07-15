using Specky.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TripCalculator.Models;

namespace TripCalculator.Dal
{
    [Speck]
    public class TripDb : ITripDb
    {
        public TripDb()
        {
            Students = MockStudents();
            Expenses = new HashSet<Expense>();
            Trips = new HashSet<Trip>();
            StudentGroups = new HashSet<StudentGroup>();
        }

        private ICollection<Student> MockStudents()
        {
            var students = new List<Student>();
            for (var i = 1; i < 5; i++)
            {
                students.Add(new() { Id = i, Name = $"Mock Student{i}" });
            }
            return students;
        }

        public ICollection<Student> Students { get; set; }
        public ICollection<Expense> Expenses { get; set; }
        public ICollection<Trip> Trips { get; set; }
        public ICollection<StudentGroup> StudentGroups { get; set; }
    }
}
