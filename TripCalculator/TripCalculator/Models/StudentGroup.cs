using System.Collections.Generic;

namespace TripCalculator.Models
{
    public class StudentGroup
    {
        public StudentGroup()
        {
            Students = new HashSet<Student>();
            Expenses = new HashSet<Expense>();
        }

        public int Id { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }
}
