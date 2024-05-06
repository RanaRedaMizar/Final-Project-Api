using Final_Project_Api.Data.Models;

namespace Final_Project_Api.Interfaces.Services
{
    public interface IAuthService
    {
        Task<ApplicationUser> Login(string username, string password);
    }
}
