using AutoMapper;
using Services.DTOs;
using TestPro.Api.ViewModels;

namespace TestPro.Api.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserViewModel, UserDTO>();
            CreateMap<LoginViewModel, LoginReqDTO>();
        }
    }
}
