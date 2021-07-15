namespace TripCalculator.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public string Destination { get; set; }
        public StudentGroup StudentGroup { get; set; }
    }
}
