namespace Expense_Tracker.Model
{
    public class User
    {
        public int ID { get; set; }     
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string EmailConfirmed { get; set; } = string.Empty;
        public string PasswordConfirmed { get; set; } = string.Empty;

    }
}
