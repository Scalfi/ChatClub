using AutoMapper;
using ChatClub.Domain.Dto;
using ChatClub.Domain.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClub.Domain.Mapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            CreateMap<UserDto, UserEntity>().ReverseMap();
            CreateMap<UserDto, LoginDto>();

        }

    }
}
