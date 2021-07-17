using TripCalculator.Models;

namespace TripCalculator.Utilities
{
    public interface ITripCalculator
    {
        MoneyDebtReport CalculateDebt(Trip trip);
    }
}