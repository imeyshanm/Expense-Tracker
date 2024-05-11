using Microsoft.EntityFrameworkCore;
using Expense_Tracker.Model;

namespace Expense_Tracker.DBContexts
{
    public class ExpenseContexts : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Currency> Currencys { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }

        public ExpenseContexts(DbContextOptions<ExpenseContexts> options) : base(options)
        {
        }


    }
}
