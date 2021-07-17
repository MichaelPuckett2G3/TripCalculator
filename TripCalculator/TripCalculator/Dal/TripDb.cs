using Specky.Attributes;
using System.Collections.Generic;
using System.Linq;
using TripCalculator.Models;

namespace TripCalculator.Dal
{
    [Speck]
    public class TripDb : ITripDb
    {
        public TripDb()
        {
            Students = MockStudents();
            Expenses = MockExpenses();
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
                    Name = "Louis"
                },
                new()
                {
                    Id = id++,
                    Name = "Carter"
                },
                 new()
                {
                    Id = id++,
                    Name = "David"
                }
            };

            return students;
        }

        private ICollection<Expense> MockExpenses()
        {
            var id = 0;
            var expenses = new List<Expense>
            {
                new()
                {
                    Id = id++,
                    Name = "Food",
                    Student = Students.First(student => student.Name.Equals("Louis")),
                    Cost = 5.75M
                },
                new()
                {
                    Id = id++,
                    Name = "Gas",
                    Student = Students.First(student => student.Name.Equals("Louis")),
                    Cost = 35.00M
                },
                 new()
                {
                    Id = id++,
                    Name = "Tickets",
                    Student = Students.First(student => student.Name.Equals("Louis")),
                    Cost = 12.79M
                },
                 new()
                {
                    Id = id++,
                    Name = "Food",
                    Student = Students.First(student => student.Name.Equals("Carter")),
                    Cost = 12.00M
                },
                new()
                {
                    Id = id++,
                    Name = "Shirt",
                    Student = Students.First(student => student.Name.Equals("Carter")),
                    Cost = 15.00M
                },
                 new()
                {
                    Id = id++,
                    Name = "Gas",
                    Student = Students.First(student => student.Name.Equals("Carter")),
                    Cost = 23.239M
                },
                 new()
                {
                    Id = id++,
                    Name = "Food",
                    Student = Students.First(student => student.Name.Equals("Louis")),
                    Cost = 10.00M
                },
                new()
                {
                    Id = id++,
                    Name = "Gas",
                    Student = Students.First(student => student.Name.Equals("Louis")),
                    Cost = 20.00M
                },
                 new()
                {
                    Id = id++,
                    Name = "Tickets",
                    Student = Students.First(student => student.Name.Equals("Louis")),
                    Cost = 38.41M
                },
                 new()
                {
                    Id = id++,
                    Name = "Fees",
                    Student = Students.First(student => student.Name.Equals("Louis")),
                    Cost = 45.00M
                }
            };

            return expenses;
        }

        public ICollection<Student> Students { get; set; }
        public ICollection<Expense> Expenses { get; set; }
        public ICollection<Trip> Trips { get; set; }
    }
}
