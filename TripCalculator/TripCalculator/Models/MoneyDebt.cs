namespace TripCalculator.Models
{
    public class MoneyDebt
    {
        public MoneyDebt(Student debtor, Student creditor, double amount)
        {
            Debtor = debtor;
            Creditor = creditor;
            Amount = amount;
        }

        public Student Debtor { get; set; }
        public Student Creditor { get; set; }
        public double Amount { get; set; }
    }
}
