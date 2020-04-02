using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingProject.Domain.Models;

namespace TrainingProject.Domain.Configurations
{
    public class UserConfiguration
    {
        public static void Configure(AppDbContext context)
        {
           /* string[] roles = new string[] { "Administrator", "Moderator", "Visitor" };

            foreach (string role in roles)
            {
                var roleStore = new RoleStore<IdentityRole>(context);

                if (!context.Roles.Any(r => r.Name == role))
                {
                    roleStore.CreateAsync(new IdentityRole(role));
                }
            }

            var admin = new User()
            {
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "Mail@example.com",
                NormalizedEmail = "MAIL@EXAMPLE.COM",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };

            if (!context.Users.Any(u => u.UserName == admin.UserName))
            {
                var password = new PasswordHasher<User>();
                var hashed = password.HashPassword(admin, "admin");
                admin.PasswordHash = hashed;

                var userStore = new UserStore<User>(context);
                userStore.CreateAsync(admin);
                userStore.AddToRoleAsync(admin, "Admin");
            } */
        }
    }
}
