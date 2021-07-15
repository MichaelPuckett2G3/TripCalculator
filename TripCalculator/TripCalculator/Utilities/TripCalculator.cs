using TripCalculator.Models;
using System.Linq;
using System.Collections.Generic;

namespace TripCalculator.Utilities
{
    public class TripCalculator
    {
        public IEnumerable<MoneyDebt> Calculate(Trip trip)
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

            var debtors = dictionary.Where(w => w.Value < individualExpense).Select(d => new MoneyTracker(d.Key, individualExpense - d.Value));
            var creditors = dictionary.Where(w => w.Value > individualExpense).Select(c => new MoneyTracker(c.Key, c.Value - individualExpense));

            List<MoneyDebt> result = new();

            foreach (var debtor in debtors)
            {
                while (debtor.Amount > 0)
                {
                    var largestCreditor = creditors.OrderByDescending(o => o.Amount).FirstOrDefault();
                    double amountPaid = 0;

                    if (debtor.Amount > largestCreditor.Amount)
                    {
                        amountPaid = largestCreditor.Amount;
                        debtor.Amount -= largestCreditor.Amount;
                        largestCreditor.Amount = 0;
                    }
                    else
                    {
                        amountPaid = debtor.Amount;
                        largestCreditor.Amount -= debtor.Amount;
                        debtor.Amount = 0;
                    }

                    // This is not updating the item in the list. Maybe a money manager would be good.
                    creditors.FirstOrDefault(f => f.Student.Id == largestCreditor.Student.Id).Amount = largestCreditor.Amount;

                    result.Add(new MoneyDebt(debtor.Student, largestCreditor.Student, amountPaid));
                }
            }

            return result;
        }
    }
}
