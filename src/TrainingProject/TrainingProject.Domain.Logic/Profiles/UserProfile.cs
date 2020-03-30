using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TrainingProject.Domain.Logic.Models.User;
using TrainingProject.Domain.Models;
using System.Security.Cryptography;
using TrainingProject.Domain.Logic.Helpers;

namespace TrainingProject.Domain.Logic.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<LoginDTO, User>()
                .ForMember(d => d.Password, opt => opt.MapFrom(src => HashGenerator.Generate(src.Password)));

            CreateMap<RegisterDTO, User>()
                .ForMember(d => d.Password, opt => opt.MapFrom(src => HashGenerator.Generate(src.Password)));

            // Configure
            CreateMap<User, ProfileDTO>();
            CreateMap<ProfileDTO, User>();


        }
    }
}
