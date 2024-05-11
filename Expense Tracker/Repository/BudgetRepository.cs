using Expense_Tracker.DBContexts;
using Expense_Tracker.Model;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Repository
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly ExpenseContexts _dbContext;

        public BudgetRepository(ExpenseContexts dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteBudget(int budgetid)
        {
            var budget = _dbContext.Budgets.Find(budgetid);
            _dbContext.Budgets.Remove(budget);
            Save();
        }

        public Budget GetBudget(int budgetId)
        {
            return _dbContext.Budgets.Include(r1 => r1.Category).FirstOrDefault(r2 => r2.Id == budgetId);
        }

        public IEnumerable<Budget> GetBudgets()
        {
            return _dbContext.Budgets.Include(r1 => r1.Category).ToList();
        }

        public void InsertBudget(Budget budget)
        {
            //_dbContext.Add(budget);
            _dbContext.Entry(budget).State = EntityState.Added;
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateBudget(Budget budget)
        {
            _dbContext.Entry(budget).State = EntityState.Modified;
            Save();
        }
    }
}
