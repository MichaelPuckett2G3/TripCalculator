using System.Collections.Generic;
using TripCalculator.Models;

namespace TripCalculator.Dal
{
    public interface ITripDb
    {
        ICollection<Expense> Expenses { get; set; }
        ICollection<StudentGroup> StudentGroups { get; set; }
        ICollection<Student> Students { get; set; }
        ICollection<Trip> Trips { get; set; }
    }
}