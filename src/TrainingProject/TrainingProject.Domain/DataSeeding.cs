using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrainingProject.Domain.Models;

namespace TrainingProject.Domain
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
            #region Populating Test
            modelBuilder.Entity<Test>().HasData(
                new
                {
                    Id = 1,
                    Name = "C# Basics",
                    Description = "Some kind of description",
                    DateCreated = DateTime.Now,
                    IsDeleted = false,
                    CategoryId = 1,
                    AuthorId = 1
                },
                new
                {
                    Id = 2,
                    Name = "C# OOP",
                    Description = "Another description",
                    DateCreated = DateTime.Parse("20-03-2020"),
                    IsDeleted = false,
                    CategoryId = 1,
                    AuthorId = 1
                },
                new
                {
                    Id = 3,
                    Name = "Java Basics",
                    Description = "Java description",
                    DateCreated = DateTime.Parse("10-03-2020"),
                    IsDeleted = false,
                    CategoryId = 2,
                    AuthorId = 1
                }
            );
            #endregion
            #region Populating Category
            modelBuilder.Entity<Category>().HasData(
                new
                {
                    Id = 1,
                    Name = "C#",
                    Description = "Test description 1",
                    IsDeleted = false
                },
                new
                {
                    Id = 2,
                    Name = "Java",
                    Description = "Test description java test 123",
                    IsDeleted = false
                }
            );
            #endregion
            #region Populating Question
            modelBuilder.Entity<Question>().HasData(
                new
                {
                    Id = 1,
                    Description = "Test 1 Question #1 text",
                    MultipleAnswers = false,
                    Image = "",
                    IsDeleted = false,
                    TestId = 1
                },
                new
                {
                    Id = 2,
                    Description = "Test 1 Question #2 text",
                    MultipleAnswers = false,
                    Image = "Some image path",
                    IsDeleted = false,
                    TestId = 1
                },
                new
                {
                    Id = 3,
                    Description = "Test 1 Question #3 text",
                    MultipleAnswers = true,
                    Image = "",
                    IsDeleted = false,
                    TestId = 1
                },
                new
                {
                    Id = 4,
                    Description = "Test 2 Question #1 text",
                    MultipleAnswers = false,
                    Image = "Image",
                    IsDeleted = false,
                    TestId = 2
                }
            );

            #endregion
            #region Populating Choices

            modelBuilder.Entity<Choice>().HasData(
                new
                {
                    Id = 1,
                    Description = "Choice 1 for question 1",
                    IsAnswer = false,
                    IsDeleted = false,
                    QuestionId = 1
                },
                new
                {
                    Id = 2,
                    Description = "Choice 2 for question 1",
                    IsAnswer = true,
                    IsDeleted = false,
                    QuestionId = 1
                },
                new
                {
                    Id = 3,
                    Description = "Choice 3 for question 1",
                    IsAnswer = false,
                    IsDeleted = false,
                    QuestionId = 1
                },
                new
                {
                    Id = 4,
                    Description = "Choice 1 for question 2",
                    IsAnswer = true,
                    IsDeleted = false,
                    QuestionId = 2
                },
                new
                {
                    Id = 5,
                    Description = "Choice 2 for question 2",
                    IsAnswer = false,
                    IsDeleted = false,
                    QuestionId = 2
                }
            );

            #endregion
            #region Populating Result

            modelBuilder.Entity<Result>().HasData(
                new
                {
                    ResultId = 1,
                    TestId = 1,
                    UserId = 1,
                    CorrectAnswers = 2,
                    TestFinished = true,
                    DateFinished = DateTime.Now,
                    IsDeleted = false
                },
                new
                {
                    ResultId = 2,
                    TestId = 2,
                    UserId = 1,
                    CorrectAnswers = 1,
                    TestFinished = false,
                    DateFinished = DateTime.Now,
                    IsDeleted = false
                }
            );

            #endregion
            #region Populating Roles
            //modelBuilder.Entity<Role>().HasData(
            //    new
            //    {
            //        Id = 1,
            //        Name = "Role name 1"
            //    });
            #endregion
        }
    }
}
