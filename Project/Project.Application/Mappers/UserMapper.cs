using AutoMapper;
using Project.Application.DTOs;
using Project.Domain.Entities;

namespace Project.Application.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserResponseDTO>().ReverseMap();
        }
    }
}
