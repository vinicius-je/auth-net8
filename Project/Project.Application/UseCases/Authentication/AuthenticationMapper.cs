using AutoMapper;
using Project.Application.DTOs;
using Project.Domain.Entities;

namespace Project.Application.UseCases.Authentication
{
    public class AuthenticationMapper : Profile
    {
        public AuthenticationMapper()
        {
            CreateMap<AuthenticationRequest, UserResponseDTO>().ReverseMap();
            CreateMap<AuthenticationRequest, UserInputDTO>().ReverseMap();
            CreateMap<AuthenticationRequest, User>().ReverseMap();
        }
    }
}
