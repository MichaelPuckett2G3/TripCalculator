using System.Collections.Generic;
using System.Linq;

namespace TripCalculator.Models
{
    public record MoneyDebtReport(IEnumerable<MoneyTracker> Creditors, IEnumerable<MoneyTracker> Debtors, IEnumerable<MoneyDebt> DebtRecord)
    {
        public decimal TotalCredit { get; } = Creditors.Sum(c => c.Amount);
        public decimal TotalDebt { get; } = Debtors.Sum(d => d.Amount);
    }
}