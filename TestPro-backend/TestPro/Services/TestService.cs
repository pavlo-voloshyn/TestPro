using Microsoft.EntityFrameworkCore;
using Services.DTOs;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPro.Domain.Infrastructure;

namespace Services
{
    public class TestService : ITestService
    {
        private readonly TestContext _context;

        public TestService(TestContext context)
        {
            _context = context;
        }

        public async Task<List<TestDTO>> GetTests(Guid id)
        {
            var user = _context.Users
                .Include(u => u.Tests)
                .ThenInclude(t => t.Questions)
                .First(u => u.Id == id);

            var response = new List<TestDTO>();

            foreach(var test in user.Tests)
            {
                var questions = new List<Ques>();
                foreach (var q in test.Questions)
                {
                    questions.Add(new Ques()
                    {
                        Answers = new List<string>() { q.Answer_A, q.Answer_B, q.Answer_C, q.Answer_D },
                        Title = q.Title
                    });
                }
                response.Add(new TestDTO()
                {
                    Id = test.Id.ToString(),
                    Desсription = test.Description,
                    Questions = questions
                });
            }

            return response;
        }

        public async Task<List<bool>> PassTest(PassTestDTO dto)
        {
            var test = _context.Tests.Include(t => t.Questions).First(test => test.Id == dto.Id);

            var response = new List<bool>();

            for(int i = 0; i < test.Questions.Count; i++)
            {
                if (dto.Answers[i] ==  test.Questions[i].RightAnswer)
                {
                    test.Questions[i].IsPassed = true;
                    response.Add(true);
                }
                else response.Add(false);
            }

            return response;
        }
    }
}
