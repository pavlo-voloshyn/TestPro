using AutoMapper;
using Services.DTOs;
using System;
using TestPro.Api.ViewModels;

namespace TestPro.Api.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserViewModel, UserDTO>();
            CreateMap<LoginViewModel, LoginReqDTO>();
            CreateMap<PassedTestViewModel, PassTestDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.Parse(src.Id)));
        }
    }
}
