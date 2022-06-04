﻿using AutoMapper;
using BE.Data.Dtos;
using BE.Data.Entities;

namespace BE.Api.Automapper
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, ListUserDto>();
            CreateMap<LoginDto, User>();
            CreateMap<User, LoggedInDto>();
        }
    }
}
