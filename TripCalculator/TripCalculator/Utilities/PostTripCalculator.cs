using TripCalculator.Models;
using System.Linq;
using System.Collections.Generic;
using System;
using Specky.Attributes;

namespace TripCalculator.Utilities
{
    [Speck]
    public class PostTripCalculator : ITripCalculator
    {
        private const decimal LowestThreshold = 0.01M;

        public MoneyDebtReport CalculateDebt(Trip trip)
        {
            if (trip is null) throw new ArgumentNullException(nameof(Trip));
            if (trip.Expenses is null) throw new ArgumentNullException($"{nameof(Trip)}.{nameof(Trip.Expenses)}");
            if (trip.Expenses.Any(expense => expense.Student is null)) throw new ArgumentNullException($"{nameof(Trip)}.{nameof(Trip.Expenses)}.{nameof(Expense.Student)}");

            var individualExpense = trip.Expenses.Sum(x => x.Cost) / trip.Expenses.Select(x => x.Student).Distinct().Count();

            // Reduce the need to calculate the dictionary only once
            var studentExpenseDictionary = trip
                .Expenses
                .GroupBy(x => x.Student)
                .ToDictionary(studentExpenses => studentExpenses.Key, studentExpenses => studentExpenses.ToList().Sum(s => s.Cost));

            var debtors = studentExpenseDictionary
                .Where(w => w.Value < individualExpense)
                .Select(d => new MoneyTracker(d.Key, individualExpense - d.Value))
                .ToList();

            var creditors = studentExpenseDictionary
                .Where(w => w.Value > individualExpense)
                .Select(c => new MoneyTracker(c.Key, c.Value - individualExpense))
                .ToList();

            List<MoneyDebt> result = new();

            foreach (var debtor in debtors)
            {
                while (debtor.Amount > LowestThreshold)
                {
                    var largestCreditor = creditors.OrderByDescending(o => o.Amount).FirstOrDefault();
                    decimal debtLeft = debtor.Amount;
                    decimal amountPaid = 0;

                    if (debtor.Amount > largestCreditor.Amount)
                    {
                        amountPaid = largestCreditor.Amount;
                        debtor.Amount -= largestCreditor.Amount;
                        debtor.Amount = debtor.Amount; // Floating point miscalculations are occurring
                        largestCreditor.Amount = 0;
                    }
                    else
                    {
                        amountPaid = debtor.Amount;
                        largestCreditor.Amount -= debtor.Amount;
                        largestCreditor.Amount = largestCreditor.Amount; // Floating point miscalculations are occurring
                        debtor.Amount = 0;
                    }

                    result.Add(new MoneyDebt(debtor.Student, largestCreditor.Student, Math.Round(amountPaid, 2, MidpointRounding.ToNegativeInfinity)));
                }
            }

            return new MoneyDebtReport(creditors, debtors, result);
        }
    }
}
