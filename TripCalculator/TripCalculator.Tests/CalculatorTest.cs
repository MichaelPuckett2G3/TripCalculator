using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TripCalculator.Models;

namespace TripCalculator.Tests
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void BaseCalculateTest()
        {
            // Arrange
            Utilities.PostTripCalculator actor = new();
            IList<Student> students = MockStudents();
            var tripId = 0;
            Trip trip = new()
            {
                Destination = "Hollywood",
                Expenses = new List<Expense>()
                {
                    // Michael Pucket - 37
                    new Expense() { Id = tripId++, Name = "Food", Cost=15M, Student=students[0]},
                    new Expense() { Id = tripId++, Name = "Food", Cost=12M, Student=students[0]},
                    new Expense() { Id = tripId++, Name = "Food", Cost=10M, Student=students[0]},
                    // Chris Gainey - 30
                    new Expense() { Id = tripId++, Name = "Food", Cost=13M, Student=students[1]},
                    new Expense() { Id = tripId++, Name = "Food", Cost=9M, Student=students[1]},
                    new Expense() { Id = tripId++, Name = "Food", Cost=8M, Student=students[1]},
                    // Cory Powell - 55
                    new Expense() { Id = tripId++, Name = "Food", Cost=10M, Student=students[2]},
                    new Expense() { Id = tripId++, Name = "Food", Cost=20M, Student=students[2]},
                    new Expense() { Id = tripId++, Name = "Food", Cost=25M, Student=students[2]},
                    // Erin Puckett - 45
                    new Expense() { Id = tripId++, Name = "Food", Cost=15M, Student=students[3]},
                    new Expense() { Id = tripId++, Name = "Food", Cost=10M, Student=students[3]},
                    new Expense() { Id = tripId++, Name = "Food", Cost=20M, Student=students[3]}
                }
            };

            // Act
            var result = actor.CalculateDebt(trip);

            // Assert
            Assert.IsTrue(result.Debtors.Any(a => a.Student.Name == "Chris Gainey"));
            Assert.AreEqual(3.25M, result.DebtRecord.Where(w => w.Creditor.Name.Equals("Erin Puckett")).Sum(s => s.Amount));
            Assert.AreEqual(13.25M, result.DebtRecord.Where(w => w.Creditor.Name.Equals("Cory Powell")).Sum(s => s.Amount));
        }

        [TestMethod]
        public void CalculateReturnsMoneyDebtWithinOneFullCent()
        {
            // Arrange
            Utilities.PostTripCalculator actor = new();
            IList<Student> students = MockStudents();
            var tripId = 0;
            Trip trip = new()
            {
                Destination = "Hollywood",
                Expenses = new List<Expense>()
                {
                    // Michael Pucket - 37
                    new Expense() { Id = tripId++, Name = "Food", Cost=15.12M, Student=students[0]},
                    new Expense() { Id = tripId++, Name = "Food", Cost=12.99M, Student=students[0]},
                    new Expense() { Id = tripId++, Name = "Food", Cost=10.00M, Student=students[0]},
                    // Chris Gainey - 30
                    new Expense() { Id = tripId++, Name = "Food", Cost=13.01M, Student=students[1]},
                    new Expense() { Id = tripId++, Name = "Food", Cost=9.55M, Student=students[1]},
                    new Expense() { Id = tripId++, Name = "Food", Cost=8.87M, Student=students[1]},
                    // Cory Powell - 55
                    new Expense() { Id = tripId++, Name = "Food", Cost=10.10M, Student=students[2]},
                    new Expense() { Id = tripId++, Name = "Food", Cost=20.34M, Student=students[2]},
                    new Expense() { Id = tripId++, Name = "Food", Cost=25.50M, Student=students[2]},
                    // Erin Puckett - 45
                    new Expense() { Id = tripId++, Name = "Food", Cost=15.00M, Student=students[3]},
                    new Expense() { Id = tripId++, Name = "Food", Cost=10.11M, Student=students[3]},
                    new Expense() { Id = tripId++, Name = "Food", Cost=20.75M, Student=students[3]}
                }
            };

            // Act
            var result = actor.CalculateDebt(trip);

            // Assert
            Assert.IsTrue((result.TotalCredit - result.DebtRecord.Sum(dr => dr.Amount)) <= 0.1M);
        }

        [TestMethod]
        public void NullParameterCheckTest()
        {
            // Arrange
            Utilities.PostTripCalculator actor = new();

            // Act and Assert
            Assert.ThrowsException<ArgumentNullException>(() => actor.CalculateDebt(null));
        }

        [TestMethod]
        public void NullExpensesCheckTest()
        {
            // Arrange
            Utilities.PostTripCalculator actor = new();
            Trip trip = new()
            {
                Destination = null,
                Expenses = null
            };

            // Act and Assert
            Assert.ThrowsException<ArgumentNullException>(() => actor.CalculateDebt(trip));
        }

        [TestMethod]
        public void NullStudentsCheckTest()
        {
            // Arrange
            Utilities.PostTripCalculator actor = new();
            Trip trip = new()
            {
                Destination = null,
                Expenses = new List<Expense>() { new(), new(), new() }
            };

            // Act and Assert
            Assert.ThrowsException<ArgumentNullException>(() => actor.CalculateDebt(trip));
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
