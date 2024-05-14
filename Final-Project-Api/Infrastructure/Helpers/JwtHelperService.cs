﻿using Final_Project_Api.Data.Models;
using Final_Project_Api.Interfaces.Helpers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Final_Project_Api.Infrastructure.Helpers
{
    public class JwtHelperService : IJwtHelpService
    {
        private SymmetricSecurityKey key;
        private IConfiguration configuration;

        public JwtHelperService(IConfiguration configuration)
        {
            this.configuration = configuration;
            key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]));
        }

        public ClaimsPrincipal DecodeToken(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler().ValidateToken(
                accessToken,
                new TokenValidationParameters()
                {
                    IssuerSigningKey = key,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                },
                out SecurityToken securityToken
            );

            return handler;
        }

        public string GenerateToken(ApplicationUser user)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,user.Email),
                
            };

            var signingCredentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256Signature
            );

            var description = new SecurityTokenDescriptor()
            {
                Issuer = configuration["JWT:Issuer"],
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddDays(30),
                Audience = configuration["JWT:Audience"],
                SigningCredentials = signingCredentials,
                Subject = new ClaimsIdentity(claims),
            };

            var handler = new JwtSecurityTokenHandler();
            var securedToken = handler.CreateToken(description);

            return handler.WriteToken(securedToken);
        }
    }

}


