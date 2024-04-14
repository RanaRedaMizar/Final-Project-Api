using Final_Project_Api.Data.DToModels;
using Final_Project_Api.Data.Models;

namespace Final_Project_Api.Interfaces.Services
{
    public interface IUserService
    {
        Task<AuthModel> RegisterAsync(RegisterDto register);
        Task<AuthModel> GetTokenAsync(LoginDto login);
       
    }
}
