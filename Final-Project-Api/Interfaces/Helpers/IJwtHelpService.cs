using Final_Project_Api.Data.Models;
using System.Security.Claims;

namespace Final_Project_Api.Interfaces.Helpers
{
    public interface IJwtHelpService
    {
        public string GenerateToken(ApplicationUser user);
        public ClaimsPrincipal DecodeToken(string accessToken);
    }
}

