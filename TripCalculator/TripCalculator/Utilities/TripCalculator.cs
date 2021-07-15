using TripCalculator.Models;
using System.Linq;
using System.Collections.Generic;

namespace TripCalculator.Utilities
{
    public class TripCalculator
    {
        public void Calculate(Trip trip)
        {
            var totalExpense = trip.Expenses.Sum(x => x.Cost);
            var uniqueStudents = trip.Expenses.Select(x => x.Student).Distinct();
            var individualExpense = totalExpense / uniqueStudents.Count();
            var dictionary = new Dictionary<Student, double>();

            foreach (var expenseGroup in trip.Expenses.GroupBy(x => x.Student))
            {
                var student = expenseGroup.Key;
                var studentCost = expenseGroup.Sum(x => x.Cost);
                dictionary.Add(student, studentCost);
            }
        }
    }
}
