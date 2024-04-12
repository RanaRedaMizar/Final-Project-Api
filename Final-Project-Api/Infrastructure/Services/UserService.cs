using Final_Project_Api.Data.DToModels;
using Final_Project_Api.Data.Models;
using Final_Project_Api.Interfaces.Repositories;
using Final_Project_Api.Interfaces.Services;

namespace Final_Project_Api.Infrastructure.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AuthModel> RegisterAsync(RegisterDto register)
        {

            return await _userRepository.RegisterAsync(register);

        }


        public async Task<AuthModel> GetTokenAsync(LoginDto login)
        {

            return await _userRepository.GetTokenAsync(login);

        }

        public async Task<string> AddRoleAsync(AddRoleModelDto addRoleModel)
        {

            return await _userRepository.AddRoleAsync(addRoleModel);

        }


    }
}
