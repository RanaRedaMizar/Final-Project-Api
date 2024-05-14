using Final_Project_Api.Data.Models;
using Final_Project_Api.Interfaces.Helpers;
using Final_Project_Api.Interfaces.Repositories;
using Final_Project_Api.Interfaces.Services;

namespace Final_Project_Api.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IApplicationUserRepository _userRepository;
      

        public AuthService(IApplicationUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApplicationUser> Login(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAndPassword(username, password);
            return user;
        }
        public string GenerateToken(ApplicationUser user)
        {
            return _userRepository.GenerateToken(user);
        }

    }
}
