using System;
using Microsoft.Extensions.DependencyInjection;
using TrainingProject.Data.Repository;
using TrainingProject.Domain;

namespace TrainingProject.Data
{
    public static class DataExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddTransient<ITestRepository, TestRepository>();
            services.AddTransient<IChoiceRepository, ChoiceRepository>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IResultRepository, ResultRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }
    }
}