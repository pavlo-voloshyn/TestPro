using Microsoft.IdentityModel.Tokens;
using Services.Constants;
using Services.DTOs;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TestPro.Domain.Entities;
using TestPro.Domain.Infrastructure;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly TestContext _context;

        public AccountService(TestContext context)
        {
            _context = context; 
        }

        public async Task CreateUser(UserDTO dto)
        {
            var user = new User()
            {                   
                Name = dto.Name,
                UserName = dto.UserName,
                Password = dto.Password
            };

            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<LoginResDTO> Login(LoginReqDTO dto)
        {
            var user = _context.Users.First(u => u.UserName == dto.UserName);
            if (user == null) throw new ArgumentException("Not found user");

            if (user.Password != dto.Password) throw new ArgumentException("Incorrect password");

            var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, "user")
                };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: claims,
                    expires: now.Add(TimeSpan.FromDays(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new LoginResDTO()
            {
                Id = user.Id.ToString(),
                Token = encodedJwt
            };

            return response;
        }
    }
}
