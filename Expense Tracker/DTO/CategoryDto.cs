using System.ComponentModel.DataAnnotations;

namespace Expense_Tracker.DTO
{
    public class CategoryDto
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
