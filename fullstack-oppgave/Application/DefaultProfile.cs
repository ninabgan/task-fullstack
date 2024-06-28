using Application.Dtos;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Application
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserRole, UserRoleDto>().ReverseMap();
        }
    }
}
