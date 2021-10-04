using Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAccountService
    {
        Task CreateUser(UserDTO dto);
        Task<LoginResDTO> Login(LoginReqDTO dto);
    }
}
