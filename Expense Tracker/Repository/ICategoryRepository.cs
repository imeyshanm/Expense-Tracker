using Expense_Tracker.Model;

namespace Expense_Tracker.Repository
{
    public interface ICategoryRepository
    {
         Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(int CategoryId);
        Task InsertCategory(Category  category);
        Task UpdateCategory(Category  category);
        Task DeleteCategory(int CategoryId);
        Task Save();
    }
}
