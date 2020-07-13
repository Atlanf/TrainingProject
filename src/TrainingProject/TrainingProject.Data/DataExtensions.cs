using System;
using Microsoft.Extensions.DependencyInjection;
using TrainingProject.Data.Repository;
using TrainingProject.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace TrainingProject.Data
{
    public static class DataExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(
                        configuration.GetConnectionString("TrainingProjectDBConnection"),
                        builder => builder.MigrationsAssembly("TrainingProject.Domain"));
            });

            services.AddRepositories();

            return services;
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ITestRepository, TestRepository>();
            services.AddTransient<IChoiceRepository, ChoiceRepository>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IResultRepository, ResultRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}