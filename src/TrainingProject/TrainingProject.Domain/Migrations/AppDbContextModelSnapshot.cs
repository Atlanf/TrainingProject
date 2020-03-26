﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrainingProject.Domain;

namespace TrainingProject.Domain.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TrainingProject.Domain.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Test description 1",
                            IsDeleted = false,
                            Name = "C#"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Test description java test 123",
                            IsDeleted = false,
                            Name = "Java"
                        });
                });

            modelBuilder.Entity("TrainingProject.Domain.Models.Choice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAnswer")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Choices");

                    b.HasData(
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
                        });
                });

            modelBuilder.Entity("TrainingProject.Domain.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("MultipleAnswers")
                        .HasColumnType("bit");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Test 1 Question #1 text",
                            Image = "",
                            IsDeleted = false,
                            MultipleAnswers = false,
                            TestId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Test 1 Question #2 text",
                            Image = "Some image path",
                            IsDeleted = false,
                            MultipleAnswers = false,
                            TestId = 1
                        },
                        new
                        {
                            Id = 3,
                            Description = "Test 1 Question #3 text",
                            Image = "",
                            IsDeleted = false,
                            MultipleAnswers = true,
                            TestId = 1
                        },
                        new
                        {
                            Id = 4,
                            Description = "Test 2 Question #1 text",
                            Image = "Image",
                            IsDeleted = false,
                            MultipleAnswers = false,
                            TestId = 2
                        });
                });

            modelBuilder.Entity("TrainingProject.Domain.Models.Result", b =>
                {
                    b.Property<int>("ResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CorrectAnswers")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateFinished")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("TestFinished")
                        .HasColumnType("bit");

                    b.Property<int?>("TestId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ResultId");

                    b.HasIndex("TestId");

                    b.HasIndex("UserId");

                    b.ToTable("Results");

                    b.HasData(
                        new
                        {
                            ResultId = 1,
                            CorrectAnswers = 2,
                            DateFinished = new DateTime(2020, 3, 26, 12, 28, 20, 530, DateTimeKind.Local).AddTicks(5683),
                            IsDeleted = false,
                            TestFinished = true,
                            TestId = 1,
                            UserId = 1
                        },
                        new
                        {
                            ResultId = 2,
                            CorrectAnswers = 1,
                            DateFinished = new DateTime(2020, 3, 26, 12, 28, 20, 530, DateTimeKind.Local).AddTicks(8987),
                            IsDeleted = false,
                            TestFinished = false,
                            TestId = 2,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("TrainingProject.Domain.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Role name 1"
                        });
                });

            modelBuilder.Entity("TrainingProject.Domain.Models.Test", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Tests");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            CategoryId = 1,
                            DateCreated = new DateTime(2020, 3, 26, 12, 28, 20, 520, DateTimeKind.Local).AddTicks(8610),
                            Description = "Some kind of description",
                            IsDeleted = false,
                            Name = "C# Basics"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 1,
                            CategoryId = 1,
                            DateCreated = new DateTime(2020, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Another description",
                            IsDeleted = false,
                            Name = "C# OOP"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 2,
                            CategoryId = 2,
                            DateCreated = new DateTime(2020, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Java description",
                            IsDeleted = false,
                            Name = "Java Basics"
                        });
                });

            modelBuilder.Entity("TrainingProject.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "SomeMail@test.by",
                            FirstName = "Ivan",
                            IsDeleted = false,
                            LastName = "Ivanov",
                            Password = "PswTest1",
                            RoleId = 1,
                            UserName = "UserIvan"
                        },
                        new
                        {
                            Id = 2,
                            Email = "SomeMail2@test.by",
                            FirstName = "Petr",
                            IsDeleted = false,
                            LastName = "Petrov",
                            Password = "PswTest2",
                            RoleId = 1,
                            UserName = "User_Petr"
                        });
                });

            modelBuilder.Entity("TrainingProject.Domain.Models.Choice", b =>
                {
                    b.HasOne("TrainingProject.Domain.Models.Question", "Question")
                        .WithMany("Choices")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TrainingProject.Domain.Models.Question", b =>
                {
                    b.HasOne("TrainingProject.Domain.Models.Test", "Test")
                        .WithMany("Questions")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TrainingProject.Domain.Models.Result", b =>
                {
                    b.HasOne("TrainingProject.Domain.Models.Test", "Test")
                        .WithMany("Results")
                        .HasForeignKey("TestId");

                    b.HasOne("TrainingProject.Domain.Models.User", "User")
                        .WithMany("Results")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TrainingProject.Domain.Models.Test", b =>
                {
                    b.HasOne("TrainingProject.Domain.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainingProject.Domain.Models.Category", "Category")
                        .WithMany("Tests")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TrainingProject.Domain.Models.User", b =>
                {
                    b.HasOne("TrainingProject.Domain.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
