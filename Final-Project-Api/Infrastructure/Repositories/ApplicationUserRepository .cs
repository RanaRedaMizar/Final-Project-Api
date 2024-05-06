using Final_Project_Api.Data;
using Final_Project_Api.Data.DToModels;
using Final_Project_Api.Data.Models;
using Final_Project_Api.Infrastructure.Helpers;
using Final_Project_Api.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Numerics;
using System.Security.Claims;
using System.Text;

namespace Final_Project_Api.Infrastructure.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ApplicationUserRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<ApplicationUser> GetUserByUsernameAndPassword(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

                if (result.Succeeded)
                {
                    return user;
                }
            }

            return null;
        }
    }
}
