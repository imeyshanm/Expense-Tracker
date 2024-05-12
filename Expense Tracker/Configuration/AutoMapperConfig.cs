using AutoMapper;
using Expense_Tracker.DTO;
using Expense_Tracker.Model;

namespace Expense_Tracker.Configuration
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
        }

    }
}
