using Specky.Attributes;
using System.Collections.Generic;
using System.Linq;
using TripCalculator.Dal;
using TripCalculator.Models;

namespace TripCalculator.ViewModels
{
    [Speck]
    public sealed class ManageExpensesViewModel
    {
        private readonly ITripDb tripDb;
        private readonly IList<Expense> expenses;

        public ManageExpensesViewModel(ITripDb tripDb)
        {
            this.tripDb = tripDb;
            expenses = tripDb.Expenses.ToList();
        }
        public IEnumerable<Expense> Expenses => expenses;

        public void AddExpense(Expense expense)
        {
            expense.Id = tripDb.Expenses.Count + 1;
            expenses.Add(expense);
        }

        public void CommitChanges()
        {
            foreach (var expense in Expenses) tripDb.Expenses.Add(expense);
        }
    }
}
