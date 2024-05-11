namespace Expense_Tracker.Model
{
    public class Expense : ITransactionType
    {
        public int Id { get; set; } 
        public double Amount { get; set; }
        public DateTime Date { get; set; } 
        public Category Category { get; set; }

        public string Description { get; set; }
        public PaymentMethod PaymentMethod { get; set; }


    }
}
