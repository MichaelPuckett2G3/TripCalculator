using Specky.Attributes;
using System.Collections.Generic;
using System.Linq;
using TripCalculator.Models;

namespace TripCalculator.Dal
{
    [Speck]
    public sealed class MockTrip : IMockTrip
    {
        public Trip GetTrip()
        {
            int id = 0x0;
            var students = MockStudents();

            return new Trip()
            {
                Id = 1,
                Destination = "Asheville, NC",
                Expenses = new List<Expense>
            {
                new()
                {
                    Id = id++,
                    Name = "Food",
                    Student = students.First(student => student.Name.Equals("Louis")),
                    Cost = 5.75M
                },
                new()
                {
                    Id = id++,
                    Name = "Gas",
                    Student = students.First(student => student.Name.Equals("Louis")),
                    Cost = 35.00M
                },
                new()
                {
                    Id = id++,
                    Name = "Tickets",
                    Student = students.First(student => student.Name.Equals("Louis")),
                    Cost = 12.79M
                },
                new()
                {
                    Id = id++,
                    Name = "Food",
                    Student = students.First(student => student.Name.Equals("Carter")),
                    Cost = 12.00M
                },
                new()
                {
                    Id = id++,
                    Name = "Shirt",
                    Student = students.First(student => student.Name.Equals("Carter")),
                    Cost = 15.00M
                },
                new()
                {
                    Id = id++,
                    Name = "Gas",
                    Student = students.First(student => student.Name.Equals("Carter")),
                    Cost = 23.239M
                },
                new()
                {
                    Id = id++,
                    Name = "Food",
                    Student = students.First(student => student.Name.Equals("David")),
                    Cost = 10.00M
                },
                new()
                {
                    Id = id++,
                    Name = "Gas",
                    Student = students.First(student => student.Name.Equals("David")),
                    Cost = 20.00M
                },
                new()
                {
                    Id = id++,
                    Name = "Tickets",
                    Student = students.First(student => student.Name.Equals("David")),
                    Cost = 38.41M
                },
                new()
                {
                    Id = id++,
                    Name = "Fees",
                    Student = students.First(student => student.Name.Equals("David")),
                    Cost = 45.00M
                }
            }
            };
        }

        private ICollection<Student> MockStudents()
        {
            var id = 0x0;

            return new List<Student>
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
        }
    }
}
