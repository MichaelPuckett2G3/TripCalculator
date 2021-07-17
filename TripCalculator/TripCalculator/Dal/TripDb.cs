using Specky.Attributes;
using System.Collections.Generic;
using TripCalculator.Models;

namespace TripCalculator.Dal
{
    [Speck]
    public class TripDb : ITripDb
    {
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
        public ICollection<Expense> Expenses { get; set; } = new HashSet<Expense>();
        public ICollection<Trip> Trips { get; set; } = new HashSet<Trip>();
    }
}
