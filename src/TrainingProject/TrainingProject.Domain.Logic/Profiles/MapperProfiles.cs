using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TrainingProject.Domain.Logic.Models.User;
using TrainingProject.Domain.Models;
using System.Security.Cryptography;
using TrainingProject.Domain.Logic.Models.Question;
using TrainingProject.Domain.Logic.Models.Test;
using System.Linq;
using TrainingProject.Domain.Logic.Models.Admin;

namespace TrainingProject.Domain.Logic.Profiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            /* User profiles */
            CreateMap<LoginDTO, User>()
                .ForMember(u => u.PasswordHash, opt => opt.MapFrom(x => x.Password));
            CreateMap<RegisterDTO, User>();
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

            CreateMap<ApproveQuestionDTO, Question>()
                .ForMember(q => q.Id, opt => opt.MapFrom(x => x.QuestionId))
                .ForMember(q => q.IsApproved, opt => opt.MapFrom(x => x.QuestionApproved));

            CreateMap<Question, QuestionDTO>()
                .ForMember(q => q.QuestionId, opt => opt.MapFrom(x => x.Id))
                .ForMember(q => q.TestId, opt => opt.MapFrom(x => x.TestId))
                .ForMember(q => q.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(q => q.Image, opt => opt.MapFrom(x => x.Image))
                .ForMember(q => q.MultipleAnswers, opt => opt.MapFrom(x => x.MultipleAnswers))
                .ForMember(q => q.Choices, opt => opt.MapFrom(x => x.Choices.Choices.ToList()));

            /* Choice profiles */

            CreateMap<CreateQuestionDTO, Choice>()
                .ForMember(c => c.Choices, opt => opt.MapFrom(x => x.Choices.ToArray()))
                .ForMember(c => c.Answers, opt => opt.MapFrom(x => x.Answers.ToArray()));

            /* Test profiles */
            CreateMap<Test, TestDetailsDTO>()
                .ForMember(t => t.TestId, opt => opt.MapFrom(x => x.Id))
                .ForMember(t => t.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(t => t.MinimizedName, opt => opt.MapFrom(x => x.MinimizedName))
                .ForMember(t => t.TestDescription, opt => opt.MapFrom(x => x.Description))
                .ForMember(t => t.QuestionsApproved, opt => opt.Ignore());

            /* Admin profiles */
            CreateMap<Question, QuestionToApproveDTO>()
                .ForMember(q => q.QuestionId, opt => opt.MapFrom(x => x.Id))
                .ForMember(q => q.Description, opt => opt.MapFrom(x => x.Description))
                .ForMember(q => q.Choices, opt => opt.MapFrom(x => x.Choices.Choices.ToList()))
                .ForMember(q => q.TestName, opt => opt.MapFrom(x => x.Test.Name))
                .ForMember(q => q.CategoryName, opt => opt.MapFrom(x => x.Test.Category.Name)); //

            CreateMap<CreateCategoryDTO, Category>()
                .ForMember(q => q.Name, opt => opt.MapFrom(x => x.CategoryName))
                .ForMember(q => q.Description, opt => opt.MapFrom(x => x.CategoryDescription));

            CreateMap<CreateTestDTO, Test>()
                .ForMember(q => q.Name, opt => opt.MapFrom(x => x.TestName))
                .ForMember(q => q.MinimizedName, opt => opt.MapFrom(x => x.ShortName))
                .ForMember(q => q.MaxQuestions, opt => opt.MapFrom(x => x.MaxQuestions))
                .ForMember(q => q.Description, opt => opt.MapFrom(x => x.TestDescription))
                .ForMember(q => q.DateCreated, opt => opt.MapFrom(x => DateTime.UtcNow))
                .ForAllOtherMembers(q => q.Ignore());
        }
    }
}
