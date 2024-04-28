using AutoMapper;
using Project.Application.DTOs;
using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Mappers
{
    public class RoleMapper : Profile
    {
        public RoleMapper() 
        {
            CreateMap<Role, RoleResponseDTO>().ReverseMap();
        }
    }
}
