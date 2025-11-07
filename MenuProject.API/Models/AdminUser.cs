// İçerik: Models/AdminUser.cs
namespace MenuProject.API.Models
{
    public class AdminUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
    }
}