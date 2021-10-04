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

            var tests = new List<Test>();

            for(int i = 0; i < 10; i++)
            {
                var questions = new List<Question>();

                for(int j = 0; j < 5; j++)
                {
                    int n = new Random().Next(3);
                    var ans_a = GetRandomSentence();
                    var ans_b = GetRandomSentence();
                    var ans_c = GetRandomSentence();
                    var ans_d = GetRandomSentence();
                    
                    string right = ans_a;
                    
                    if (n == 1)
                        right = ans_b;
                    else if (n == 2)
                        right = ans_c;
                    else if (n == 3)
                        right = ans_d;

                    questions.Add(new Question()
                    {
                        Title = GetRandomSentence(),
                        Answer_A = ans_a,
                        Answer_B = ans_b,
                        Answer_C = ans_c,
                        Answer_D = ans_d,
                        RightAnswer = right,
                        IsPassed = false
                    });
                }


                tests.Add(new Test()
                {
                    Description = GetRandomSentence(),
                    IsPassed = false,
                    Questions = questions,
                    User = user
                });
            }
            
            user.Tests = tests;

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
                Token = encodedJwt,
                Name = user.Name
            };

            return response;
        }

        private string GetRandomSentence()
        {
            Random random = new Random();
            string[] words = { "Aliquam", " erat ", "volutpat.", "Aliquam", " consequat ", "malesuada ", "interdum.", "Phasellus ", "scelerisque ", "arcu ", "purus,", " quis", " ultrices", " lacus", " rutrum", " id.Quisque", " pellentesque", " elit", " sit", " amet" };

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < words.Length; i++)
            {
                builder.Append(words[random.Next(words.Length)]).Append(" ");
            }

            string sentence = builder.ToString().Trim() + ". ";

            sentence = char.ToUpper(sentence[0]) + sentence.Substring(1);

            builder = new StringBuilder();
            builder.Append(sentence);

            return builder.ToString();
        }
    }
}
