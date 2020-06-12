using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrainingProject.Data.Models;

namespace TrainingProject.Data
{
    public static class DataSeeding
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            #region Populating User

            //modelBuilder.Entity<User>().HasData(
            //    new
            //    {
            //        Id = 1,
            //        FullName = "Ivan Ivanov",
            //        UserName = "UserIvan",
            //        Password = "PswTest1",
            //        Email = "SomeMail@test.by",
            //        RoleId = 1,
            //        IsDeleted = false
            //    },
            //    new
            //    {
            //        Id = 2,
            //        FullName = "Petr Petrov",
            //        UserName = "User_Petr",
            //        Password = "PswTest2",
            //        Email = "SomeMail2@test.by",
            //        RoleId = 1,
            //        IsDeleted = false
            //    } 
            //);
            #endregion
            //#region Populating Test
            //modelBuilder.Entity<Test>().HasData(
            //    new
            //    {
            //        Id = 1,
            //        Name = "C# Basics",
            //        MinimizedName = "cs-basics",
            //        Description = "Some kind of description",
            //        DateCreated = DateTime.Now,
            //        MaxQuestions = 10,
            //        IsDeleted = false,
            //        CategoryId = 1,
            //        AuthorId = 1
            //    },
            //    new
            //    {
            //        Id = 2,
            //        Name = "C# OOP",
            //        MinimizedName = "cs-oop",
            //        Description = "Another description",
            //        DateCreated = DateTime.Parse("20-03-2020"),
            //        MaxQuestions = 10,
            //        IsDeleted = false,
            //        CategoryId = 1,
            //        AuthorId = 1
            //    },
            //    new
            //    {
            //        Id = 3,
            //        Name = "Java Basics",
            //        MinimizedName = "java-basics",
            //        Description = "Java description",
            //        DateCreated = DateTime.Parse("10-03-2020"),
            //        MaxQuestions = 15,
            //        IsDeleted = false,
            //        CategoryId = 2,
            //        AuthorId = 1
            //    }
            //);
            //#endregion
            //#region Populating Category
            //modelBuilder.Entity<Category>().HasData(
            //    new
            //    {
            //        Id = 1,
            //        Name = "C#",
            //        Description = "Test description 1",
            //        IsDeleted = false
            //    },
            //    new
            //    {
            //        Id = 2,
            //        Name = "Java",
            //        Description = "Test description java test 123",
            //        IsDeleted = false
            //    }
            //);
            //#endregion
            //#region Populating Question
            //modelBuilder.Entity<Question>().HasData(
            //    new
            //    {
            //        Id = 1,
            //        Description = "Test 1 Question #1 text",
            //        MultipleAnswers = false,
            //        Image = "",
            //        IsDeleted = false,
            //        TestId = 1,
            //        AuthorId = 1
            //    },
            //    new
            //    {
            //        Id = 2,
            //        Description = "Test 1 Question #2 text",
            //        MultipleAnswers = true,
            //        Image = "Some image path",
            //        IsDeleted = false,
            //        TestId = 1,
            //        AuthorId = 1
            //    },
            //    new
            //    {
            //        Id = 3,
            //        Description = "Test 1 Question #3 text",
            //        MultipleAnswers = true,
            //        Image = "",
            //        IsDeleted = false,
            //        TestId = 1,
            //        AuthorId = 1
            //    },
            //    new
            //    {
            //        Id = 4,
            //        Description = "Test 2 Question #1 text",
            //        MultipleAnswers = false,
            //        Image = "Image",
            //        IsDeleted = false,
            //        TestId = 2,
            //        AuthorId = 1
            //    }
            //);

            //#endregion
            //#region Populating Choices

            //modelBuilder.Entity<Choice>().HasData(
            //    new
            //    {
            //        Id = 1,
            //        Choices = new string[] { "choice 1", "choice 2", "choice 3" },
            //        Answers = new int[] { 1 },
            //        IsDeleted = false,
            //        QuestionId = 1
            //    },
            //    new
            //    {
            //        Id = 2,
            //        Choices = new string[] { "choice 4", "choice 5", "choice 6", "choice 7" },
            //        Answers = new int[] { 1, 2 },
            //        IsDeleted = false,
            //        QuestionId = 2
            //    },
            //    new
            //    {
            //        Id = 3,
            //        Choices = new string[] { "choice 8", "choice 9", "choice 10", "choice 11" },
            //        Answers = new int[] { 1, 3 },
            //        IsDeleted = false,
            //        QuestionId = 3
            //    },
            //    new
            //    {
            //        Id = 4,
            //        Choices = new string[] { "choice 12", "choice 13", "choice 14", "choice 15" },
            //        Answers = new int[] { 2 },
            //        IsDeleted = false,
            //        QuestionId = 4
            //    }
            //);

            //#endregion
            //#region Populating Result

            //modelBuilder.Entity<Result>().HasData(
            //    new
            //    {
            //        ResultId = 1,
            //        TestId = 1,
            //        UserId = 1,
            //        CorrectAnswers = 2,
            //        TestFinished = true,
            //        DateFinished = DateTime.Now,
            //        IsDeleted = false
            //    },
            //    new
            //    {
            //        ResultId = 2,
            //        TestId = 2,
            //        UserId = 1,
            //        CorrectAnswers = 1,
            //        TestFinished = false,
            //        DateFinished = DateTime.Now,
            //        IsDeleted = false
            //    }
            //);

            //#endregion
            #region Populating Roles

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "Visitor",
                    NormalizedName = "VISITOR"
                },
                new IdentityRole
                {
                    Name = "Moderator",
                    NormalizedName = "MODERATOR"
                },
                new IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                });

            #endregion
        }

        public static void SeedIdentity(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        public static void SeedUsers(UserManager<User> userManager)
        {
            if (userManager.FindByNameAsync("user1").Result == null)
            {
                var user = new User();
                user.UserName = "user1";
                user.Email = "example@example.com";
                user.FullName = "Nancy Davolio";

                IdentityResult result = userManager.CreateAsync(user, "1Pass_word").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Visitor").Wait();
                }
            }

            if (userManager.FindByNameAsync("admin").Result == null)
            {
                var user = new User();
                user.UserName = "admin";
                user.Email = "mail@example.com";
                user.FullName = "Mark Smith";

                IdentityResult result = userManager.CreateAsync(user, "Admin_1").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }

        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roles = new string[] { "Administrator", "Moderator", "Visitor" };

            foreach (string role in roles)
            {
                if (!roleManager.RoleExistsAsync(role).Result)
                {
                    roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
