using Expense_Tracker.DBContexts;
using Expense_Tracker.Migrations;
using Expense_Tracker.Model;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
          private readonly ExpenseContexts _dbContext;
        public CategoryRepository(ExpenseContexts dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteCategory(int CategoryId)
        {
            var category = await _dbContext.Categorys.FindAsync(CategoryId);
            _dbContext.Categorys.Remove(category);
            await Save();
        }

        public async Task<Category> GetCategory(int CategoryId)
        {
            var category = _dbContext.Categorys.FirstOrDefaultAsync(r2 => r2.CategoryID == CategoryId);
            if (category==null)
            {
                return  null;
            }
            return await category;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _dbContext.Categorys.ToListAsync();
        }

        public async Task InsertCategory(Category  category)
        {
            //_dbContext.Add(budget);
          _dbContext.Entry(category).State = EntityState.Added;
          await Save();
        }

        public async Task Save()
        {
           await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCategory(Category category)
        {
            _dbContext.Entry(category).State = EntityState.Modified;
           await Save();
        }

        
    }
}
