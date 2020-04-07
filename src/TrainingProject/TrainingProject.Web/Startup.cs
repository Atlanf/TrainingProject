using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TrainingProject.Data;
using TrainingProject.Domain.Logic;
using TrainingProject.Domain.Logic.Profiles;
using TrainingProject.Domain.Models;

namespace TrainingProject.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration; 
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddOpenApiDocument(c => c.DocumentName = "API v1");

            DataExtensions.AddDataServices(services); //

            services.AddLogging();

            services.AddDbContext<Domain.AppDbContext>(options =>
            {
                options.UseSqlServer(
                        Configuration.GetConnectionString("TrainingProjectDBConnection"),
                        builder => builder.MigrationsAssembly("TrainingProject.Domain"));
            });

            services.AddIdentity<Domain.Models.User, IdentityRole>()
                .AddEntityFrameworkStores<Domain.AppDbContext>();


            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfiles());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddDomainServices();
            
            services.AddControllers();

            services.AddControllersWithViews().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //services.AddSwaggerGen(options => options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            //{
            //    Title = "Training Project",
            //    Version = "v1"
            //}));
            services.AddSwaggerDocument();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwaggerUI(options => {
                //    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Training Project v1");
                //});
                app.UseOpenApi().UseSwaggerUi3();
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}

//{
//  "email": "mail@example.com",
//  "password": "Admin_1",
//  "rememberMe": true
//}


//{
//  "userName": "Name",
//  "email": "user@example.com",
//  "password": "1_User",
//  "confirmPassword": "1_User"
//}

//{
//  "email": "test@example.com",
//  "password": "T_est1",
//  "rememberMe": true
//}