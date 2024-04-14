using Final_Project_Api.Data.DToModels;
using Final_Project_Api.Data.Models;
using System.IdentityModel.Tokens.Jwt;

namespace Final_Project_Api.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<AuthModel> RegisterAsync(RegisterDto register);
        Task<AuthModel> GetTokenAsync(LoginDto login);
        Task<JwtSecurityToken> GenerateJwtToken(ApplicationUser user);
    }
}
