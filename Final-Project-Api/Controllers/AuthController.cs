using Final_Project_Api.Data.DToModels;
using Final_Project_Api.Data.Models;
using Final_Project_Api.Infrastructure.Helpers;
using Final_Project_Api.Interfaces.Repositories;
using Final_Project_Api.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Final_Project_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
       

        public AuthController(IAuthService authService)
        {
            _authService = authService;
           
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto model)
        {
            var user = await _authService.Login(model.Email, model.Password);

            if (user == null)
            {
                return NotFound("User Not Found");
            }
            var token = _authService.GenerateToken(user);

            return Ok(new { Token = token });
        }

    }
}
