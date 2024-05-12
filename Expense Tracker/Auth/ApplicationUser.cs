using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Auth
{    public class ApplicationUser : IdentityUser
    {
        public  string? TokenType { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime AccessTokenExpiryTime { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
