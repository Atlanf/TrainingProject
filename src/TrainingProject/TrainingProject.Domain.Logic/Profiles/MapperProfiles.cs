using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TrainingProject.Domain.Models.User;
using TrainingProject.Data.Models;
using System.Security.Cryptography;
using TrainingProject.Domain.Models.Question;
using TrainingProject.Domain.Models.Test;
using System.Linq;
using TrainingProject.Domain.Models.Admin;
using TrainingProject.Domain.Models.Result;

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
            CreateMap<User, ProfileDTO>();

            // Configure
            CreateMap<User, ProfileDTO>();
            CreateMap<ProfileDTO, User>();

            /* Question profiles */

            CreateMap<CreateQuestionDTO, Question>()
                .ForMember(q => q.Description, opt => opt.MapFrom(x => x.QuestionDescription))
                .ForMember(q => q.MultipleAnswers, opt => opt.MapFrom(x => x.MultipleAnswers))
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

            CreateMap<UpdatedQuestionDTO, Question>()
                .ForPath(q => q.Choices.Choices, opt => opt.MapFrom(x => x.Choices));
                //.ForMember(q => q.Choices.Choices, opt => opt.MapFrom(x => x.Choices));

            /* Result profiles */
            CreateMap<Result, ResultDTO>()
                .ForMember(q => q.CorrectAnswers, opt => opt.MapFrom(x => x.CorrectAnswers))
                .ForMember(q => q.DateFinished, opt => opt.MapFrom(x => x.DateFinished))
                .ForMember(q => q.TestFinished, opt => opt.MapFrom(x => x.TestFinished))
                .ForMember(q => q.TestId, opt => opt.MapFrom(x => x.TestId))
                .ForMember(q => q.UserName, opt => opt.MapFrom(x => x.User.UserName))
                .ForMember(q => q.TestShortName, opt => opt.MapFrom(x => x.Test.MinimizedName))
                .ForMember(q => q.TotalQuestions, opt => opt.MapFrom(x => x.Test.MaxQuestions))
                .ForAllOtherMembers(q => q.Ignore());

            CreateMap<Result, MinimizedResultDTO>()
                .ForMember(q => q.CorrectAnswers, opt => opt.MapFrom(x => x.CorrectAnswers))
                .ForMember(q => q.TestFinished, opt => opt.MapFrom(x => x.TestFinished))
                .ForMember(q => q.TotalQuestions, opt => opt.Ignore());
        }
    }
}
