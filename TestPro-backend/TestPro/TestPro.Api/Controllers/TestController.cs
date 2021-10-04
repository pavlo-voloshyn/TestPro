using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.Interfaces;
using System;
using System.Threading.Tasks;
using TestPro.Api.ViewModels;

namespace TestPro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly IMapper _mapper;

        public TestController(ITestService accountService, IMapper mapper)
        {
            _testService = accountService;
            _mapper = mapper;
        }

        [HttpGet("tests")]
        public async Task<IActionResult> Tests(string user_id)
        {
            Guid id = Guid.Parse(user_id);

            var result = await _testService.GetTests(id);
            return Ok(result);
        }

        [HttpPost("check_tests")]
        public async Task<IActionResult> CheckTests(PassedTestViewModel view)
        {
            var dto = _mapper.Map<PassTestDTO>(view);

            var result = await _testService.PassTest(dto);
            return Ok(result);
        }
    }
}
