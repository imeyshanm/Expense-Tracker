namespace Expense_Tracker.Model
{
    public class Income : ITransactionType
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public Source Source { get; set; }
        public string Description { get; set; }
    }
}
