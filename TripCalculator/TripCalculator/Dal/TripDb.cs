using Specky.Attributes;
using System.Collections.Generic;
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
        }

        private ICollection<Student> MockStudents()
        {
            var id = 0;
            var students = new List<Student>
            {
                new()
                {
                    Id = id++,
                    Name = "Michael Puckett"
                },
                new()
                {
                    Id = id++,
                    Name = "Chris Gainey"
                },
                 new()
                {
                    Id = id++,
                    Name = "Cory Powell"
                },
                new()
                {
                    Id = id++,
                    Name = "Erin Puckett"
                },
            };

            return students;
        }

        public ICollection<Student> Students { get; set; }
        public ICollection<Expense> Expenses { get; set; }
        public ICollection<Trip> Trips { get; set; }
    }
}
