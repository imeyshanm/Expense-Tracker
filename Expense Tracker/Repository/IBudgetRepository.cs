using Expense_Tracker.Model;

namespace Expense_Tracker.Repository
{
    public interface IBudgetRepository
    {
        IEnumerable<Budget> GetBudgets();
        Budget GetBudget(int budgetId);
        void InsertBudget(Budget budget);
        void UpdateBudget(Budget budget);
        void DeleteBudget(int budgetid);
        void Save();

    }
}
