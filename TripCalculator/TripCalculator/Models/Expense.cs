namespace TripCalculator.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public double Cost { get; set; }
        public string Name { get; set; }
        public Student Student { get; set; }
    }
}
