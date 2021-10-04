using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.Interfaces;
using System.Threading.Tasks;
using TestPro.Api.ViewModels;

namespace TestPro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountController(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        [HttpPost("logup")]
        public async Task<IActionResult> Create(UserViewModel view)
        {
            var dto = _mapper.Map<UserDTO>(view);
            await _accountService.CreateUser(dto);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel view)
        {
            var dto = _mapper.Map<LoginReqDTO>(view);
            var response = await _accountService.Login(dto);
            return Ok(response);
        }

    }
}
