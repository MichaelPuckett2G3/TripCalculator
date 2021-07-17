namespace TripCalculator.Models
{
    public class MoneyTracker
    {
        public MoneyTracker(Student student, decimal amount)
        {
            Student = student;
            Amount = amount;
        }

        public Student Student { get; set; }
        public decimal Amount { get; set; }
    }
}
