using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TrainingProject.Domain.Logic.Models.User;
using TrainingProject.Domain.Models;
using System.Security.Cryptography;

namespace TrainingProject.Domain.Logic.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<LoginDTO, User>()
                .ForMember(u => u.PasswordHash, opt => opt.MapFrom(x => x.Password));

            CreateMap<RegistrationDTO, User>();
                //.ForMember(u => u.UserName, opt => opt.MapFrom(x => x.UserName))
                //.ForMember(m => m.Email, opt => opt.MapFrom(x => x.Email));

            // Configure
            CreateMap<User, ProfileDTO>();
            CreateMap<ProfileDTO, User>();


        }
    }
}
