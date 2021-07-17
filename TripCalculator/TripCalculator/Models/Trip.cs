using System.Collections.Generic;

namespace TripCalculator.Models
{
    public class Trip
    {
        public Trip()
        {
            Expenses = new HashSet<Expense>();
        }

        public int Id { get; set; }
        public string Destination { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }
}
