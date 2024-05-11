namespace Expense_Tracker.Model
{
    public class TransactionType
    {
        public int Id { get; set; }
        public string Name { get; set; }
       // public ITransactionType Type { get; set; }

        public double Amount { get; set; }

        public DateTime  Date { get; set; } 

        public Category Category { get; set; }

        public string Description { get; set; }
    }
}
