﻿using AutoMapper;
using RegymBot.Data.Entities;
using RegymBot.Data.Models;
using System.Linq;

namespace RegymBot.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UserEntity, UserModel>()
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.UserRoles.Select(
                    r => r.Role.Role).ToList()));

            CreateMap<UserModel, UserEntity>()
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ForMember(dest => dest.UserRoles, opt => opt.Ignore());
        }
    }
}