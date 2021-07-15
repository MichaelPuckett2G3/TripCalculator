namespace TripCalculator.Models
{
    public class MoneyTracker
    {
        public MoneyTracker(Student student, double amount)
        {
            Student = student;
            Amount = amount;
        }

        public Student Student { get; set; }
        public double Amount { get; set; }
    }
}
