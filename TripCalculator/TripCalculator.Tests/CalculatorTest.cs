using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using TripCalculator.Models;

namespace TripCalculator.Tests
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void Calculate()
        {
            // Arrange
            Utilities.TripCalculator actor = new();
            IList<Student> students = MockStudents();
            var tripId = 0;
            Trip trip = new()
            {
                Destination = "Hollywood",
                Expenses = new List<Expense>()
                {
                    // Michael Pucket - 37
                    new Expense() { Id = tripId++, Name = "Food", Cost=15, Student=students[0]},
                    new Expense() { Id = tripId++, Name = "Food", Cost=12, Student=students[0]},
                    new Expense() { Id = tripId++, Name = "Food", Cost=10, Student=students[0]},
                    // Chris Gainey - 30
                    new Expense() { Id = tripId++, Name = "Food", Cost=13, Student=students[1]},
                    new Expense() { Id = tripId++, Name = "Food", Cost=9, Student=students[1]},
                    new Expense() { Id = tripId++, Name = "Food", Cost=8, Student=students[1]},
                    // Cory Powell - 55
                    new Expense() { Id = tripId++, Name = "Food", Cost=10, Student=students[2]},
                    new Expense() { Id = tripId++, Name = "Food", Cost=20, Student=students[2]},
                    new Expense() { Id = tripId++, Name = "Food", Cost=25, Student=students[2]},
                    // Erin Puckett - 45
                    new Expense() { Id = tripId++, Name = "Food", Cost=15, Student=students[3]},
                    new Expense() { Id = tripId++, Name = "Food", Cost=10, Student=students[3]},
                    new Expense() { Id = tripId++, Name = "Food", Cost=20, Student=students[3]}
                }
            };

            // Act
            var result = actor.Calculate(trip);

            // Assert
            Assert.IsTrue(result.Any(a => a.Debtor.Name == "Chris Gainey"));
        }
        private static IList<Student> MockStudents()
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
    }
}
