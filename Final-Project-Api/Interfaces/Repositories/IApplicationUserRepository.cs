using Final_Project_Api.Data.DToModels;
using Final_Project_Api.Data.Models;
using System.IdentityModel.Tokens.Jwt;

namespace Final_Project_Api.Interfaces.Repositories
{
    public interface IApplicationUserRepository
    {
        Task<ApplicationUser> GetUserByUsernameAndPassword(string username, string password);
        string GenerateToken(ApplicationUser user);
    }

}