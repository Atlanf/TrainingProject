using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TrainingProject.Domain.Logic.Models.User;
using TrainingProject.Domain.Models;
using System.Security.Cryptography;
using TrainingProject.Domain.Logic.Models.Question;

namespace TrainingProject.Domain.Logic.Profiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            /* User profiles */
            CreateMap<LoginDTO, User>()
                .ForMember(u => u.PasswordHash, opt => opt.MapFrom(x => x.Password));
            CreateMap<RegistrationDTO, User>();
            // Configure
            CreateMap<User, ProfileDTO>();
            CreateMap<ProfileDTO, User>();

            /* Question profiles */
            CreateMap<CreateQuestionDTO, Question>()
                .ForMember(q => q.Description, opt => opt.MapFrom(x => x.QuestionDescription))
                .ForMember(q => q.MultipleAnswers, opt => opt.MapFrom(x => x.MultipleAnswers))
                .ForMember(q => q.Image, opt => opt.MapFrom(x => x.QuestionImage))
                .ForMember(q => q.AuthorId, opt => opt.MapFrom(x => x.UserId))
                .ForMember(q => q.TestId, opt => opt.MapFrom(x => x.TestId))
                .ForMember(q => q.Choices, opt => opt.Ignore());

            CreateMap<CreateQuestionDTO, Choice>()
                .ForMember(q => q.Choices, opt => opt.MapFrom(x => x.Choices))
                .ForMember(q => q.Answers, opt => opt.MapFrom(x => x.Answers));

            CreateMap<ApproveQuestionDTO, Question>()
                .ForMember(q => q.Id, opt => opt.MapFrom(x => x.QuestionId))
                .ForMember(q => q.IsApproved, opt => opt.MapFrom(x => x.QuestionApproved));
        }
    }
}
