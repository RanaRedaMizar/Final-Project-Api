using Final_Project_Api.Data;
using Final_Project_Api.Data.DToModels;
using Final_Project_Api.Data.Models;
using Final_Project_Api.Infrastructure.Helpers;
using Final_Project_Api.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Final_Project_Api.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWTSettings _jwt;

        public UserRepository(UserManager<ApplicationUser> userManager, IOptions<JWTSettings> jwt, RoleManager<IdentityRole> roleManager, AppDbContext context)
        {
            _userManager = userManager;
            _jwt = jwt.Value;
            _roleManager = roleManager;
            _context = context;
        }

        public async Task<AuthModel> RegisterAsync(RegisterDto register)
        {
            if (await _userManager.FindByEmailAsync(register.Email) is not null)

                return new AuthModel { Message = "Email is Already Registread" };

            if (await _userManager.FindByNameAsync(register.Username) is not null)
                return new AuthModel { Message = "Username is Already Registread" };

            var user = new ApplicationUser
            {

                FirstName = register.FirstName,
                LastName = register.LastName,
                Email = register.Email,
                Image = register.Image,
                Phone = register.Phone,
                UserName = register.Username,
                Gender = register.Gender,
            };

            var result = await _userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
            {
                var errors = string.Empty;
                foreach (var error in result.Errors)
                {
                    errors += $"Errors Found {error.Description} , ";
                }
                return new AuthModel { Message = errors };
            }

            await _userManager.AddToRoleAsync(user, "Patient");

            var patient = new Patient
            {
                Id = register.Id,
                Phone = register.Phone,
                Email = register.Email,
                FirstName = register.FirstName,
                LastName = register.LastName,
                Gender = register.Gender,
                Image = register.Image,
                BirthDate = register.Birthdate
            };

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();


            var jwtSecurityToken = await GenerateJwtToken(user);

            return new AuthModel
            {
                ExpiresOn = jwtSecurityToken.ValidTo,
                Email = user.Email,
                IsAuthenticated = true,
                Roles = new List<string> { "Patient" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Username = user.UserName

            };
        }



        public async Task<JwtSecurityToken> GenerateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var rolesClaims = new List<Claim>();

            foreach (var role in roles)
            {
                rolesClaims.Add(new Claim("roles", role));
            }

            var Claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim("uid",user.Id),
            }
            .Union(rolesClaims)
            .Union(userClaims);

            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredntials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(

                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: Claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredntials

                );

            return jwtSecurityToken;

        }


        public async Task<AuthModel> GetTokenAsync(LoginDto login)
        {
            var authmodel = new AuthModel();
            var user = await _userManager.FindByEmailAsync(login.Email);


            if (user == null || !await _userManager.CheckPasswordAsync(user, login.Password))
            {
                authmodel.Message = "Email or Password is incorrect";
                return authmodel;

            }

            var jwtSecurityToken = await GenerateJwtToken(user);

            LogTokenClaims(jwtSecurityToken);

            var rolelist = await _userManager.GetRolesAsync(user);


            authmodel.IsAuthenticated = true;
            authmodel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authmodel.Email = login.Email;
            authmodel.ExpiresOn = jwtSecurityToken.ValidTo;
            authmodel.Roles = rolelist.ToList();

            return authmodel;
        }


        private void LogTokenClaims(JwtSecurityToken token)
        {

            foreach (var claim in token.Claims)
            {
                Console.WriteLine($"Claim Type: {claim.Type}, Value: {claim.Value}");
            }

        }


        public async Task<string> AddRoleAsync(AddRoleModelDto addRoleModel)
        {
            var user = await _userManager.FindByIdAsync(addRoleModel.UserId);

            if (user is null || !await _roleManager.RoleExistsAsync(addRoleModel.RoleName))
                return "Invalid user id or Role name";


            if (await _userManager.IsInRoleAsync(user, addRoleModel.RoleName))
                return "user already assigned to this role";

            var result = await _userManager.AddToRoleAsync(user, addRoleModel.RoleName);

            return result.Succeeded ? string.Empty : "Somthing went wrong";

        }

    }
}

