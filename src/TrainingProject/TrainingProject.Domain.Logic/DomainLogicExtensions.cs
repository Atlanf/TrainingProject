using System;
using Microsoft.Extensions.DependencyInjection;
using TrainingProject.Data;
using TrainingProject.Domain.Logic.Interfaces;
using TrainingProject.Domain.Logic.Services;

namespace TrainingProject.Domain.Logic
{
    public static class DomainLogicExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddDataServices();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<ITestService, TestService>();
            services.AddTransient<IResultService, ResultService>();

            //configure your Domain Logic Layer services here
            return services;
        }
    }
}