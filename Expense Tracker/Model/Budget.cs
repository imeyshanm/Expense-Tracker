namespace Expense_Tracker.Model
{
    public class Budget
    {
        public int Id { get; set; }
         public Category Category { get; set; }
        public double Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
