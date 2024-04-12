using System.Security.Claims;

namespace Final_Project_Api.Interfaces.Helpers
{
    public interface IJwtHelpService
    {
        public string GenerateToken(string email, string userId, string roleName);
        public ClaimsPrincipal DecodeToken(string accessToken);
    }
}

