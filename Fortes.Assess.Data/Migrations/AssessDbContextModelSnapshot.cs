﻿// <auto-generated />
using System;
using Fortes.Assess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fortes.Assess.Data.Migrations
{
    [DbContext(typeof(AssessDbContext))]
    partial class AssessDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fortes.Assess.Domain.AdminPage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssessmentId");

                    b.Property<string>("Body");

                    b.Property<string>("Footer");

                    b.Property<string>("Header");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("AdminPages");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.Assessment", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AdminPageId");

                    b.Property<int?>("AdminPageId1");

                    b.Property<string>("CompanyId");

                    b.Property<string>("Description");

                    b.Property<string>("DurationId");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("FieldId");

                    b.Property<string>("FrameworkId");

                    b.Property<string>("IndustryId");

                    b.Property<string>("LevelId");

                    b.Property<string>("OccupationId");

                    b.Property<int>("PassingGrade");

                    b.Property<string>("ProgrammingLanguageId");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("UserPageId");

                    b.Property<int?>("UserPageId1");

                    b.HasKey("Id");

                    b.HasIndex("AdminPageId1");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DurationId");

                    b.HasIndex("FieldId");

                    b.HasIndex("FrameworkId");

                    b.HasIndex("IndustryId");

                    b.HasIndex("LevelId");

                    b.HasIndex("OccupationId");

                    b.HasIndex("ProgrammingLanguageId");

                    b.HasIndex("UserPageId1");

                    b.ToTable("Assessments");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.AssessmentQuestion", b =>
                {
                    b.Property<string>("AssessmentId");

                    b.Property<string>("QuestionId");

                    b.HasKey("AssessmentId", "QuestionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("AssessmentQuestion");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.AssessmentUser", b =>
                {
                    b.Property<string>("AssessmentId");

                    b.Property<int>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("AssessmentId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("AssessmentUser");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.Company", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("IndustryId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("IndustryId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.Duration", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Durations");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.Field", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.Framework", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Frameworks");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.Industry", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Industries");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.Level", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.Occupation", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Occupations");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<bool>("IsCorrect");

                    b.Property<string>("QuestionId");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Option");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.ProgrammingLanguage", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ProgrammingLanguages");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.Question", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Description");

                    b.Property<string>("DurationId");

                    b.Property<string>("Explanation");

                    b.Property<string>("LevelId");

                    b.Property<string>("QuestionTypeId");

                    b.HasKey("Id");

                    b.HasIndex("DurationId");

                    b.HasIndex("LevelId");

                    b.HasIndex("QuestionTypeId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.QuestionTag", b =>
                {
                    b.Property<string>("QuestionId");

                    b.Property<string>("TagId");

                    b.HasKey("QuestionId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("QuestionTag");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.QuestionType", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("QuestionTypes");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.Role", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.Tag", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyId");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.Property<string>("email");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.UserPage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AssessmentId");

                    b.Property<string>("Body");

                    b.Property<string>("Footer");

                    b.Property<string>("Header");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("UserPages");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.Assessment", b =>
                {
                    b.HasOne("Fortes.Assess.Domain.AdminPage", "AdminPage")
                        .WithMany()
                        .HasForeignKey("AdminPageId1");

                    b.HasOne("Fortes.Assess.Domain.Company")
                        .WithMany("Assessments")
                        .HasForeignKey("CompanyId");

                    b.HasOne("Fortes.Assess.Domain.Duration")
                        .WithMany("Assessments")
                        .HasForeignKey("DurationId");

                    b.HasOne("Fortes.Assess.Domain.Field")
                        .WithMany("Assessments")
                        .HasForeignKey("FieldId");

                    b.HasOne("Fortes.Assess.Domain.Framework")
                        .WithMany("Assessments")
                        .HasForeignKey("FrameworkId");

                    b.HasOne("Fortes.Assess.Domain.Industry")
                        .WithMany("Assessments")
                        .HasForeignKey("IndustryId");

                    b.HasOne("Fortes.Assess.Domain.Level")
                        .WithMany("Assessments")
                        .HasForeignKey("LevelId");

                    b.HasOne("Fortes.Assess.Domain.Occupation")
                        .WithMany("Assessments")
                        .HasForeignKey("OccupationId");

                    b.HasOne("Fortes.Assess.Domain.ProgrammingLanguage")
                        .WithMany("Assessments")
                        .HasForeignKey("ProgrammingLanguageId");

                    b.HasOne("Fortes.Assess.Domain.UserPage", "UserPage")
                        .WithMany()
                        .HasForeignKey("UserPageId1");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.AssessmentQuestion", b =>
                {
                    b.HasOne("Fortes.Assess.Domain.Assessment", "Assessment")
                        .WithMany("AssessmentQuestions")
                        .HasForeignKey("AssessmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fortes.Assess.Domain.Question", "Question")
                        .WithMany("QuestionAssessments")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fortes.Assess.Domain.AssessmentUser", b =>
                {
                    b.HasOne("Fortes.Assess.Domain.Assessment", "Assessment")
                        .WithMany("AssessmentUsers")
                        .HasForeignKey("AssessmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fortes.Assess.Domain.User", "User")
                        .WithMany("UserAssessments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fortes.Assess.Domain.Company", b =>
                {
                    b.HasOne("Fortes.Assess.Domain.Industry")
                        .WithMany("Companies")
                        .HasForeignKey("IndustryId");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.Option", b =>
                {
                    b.HasOne("Fortes.Assess.Domain.Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.Question", b =>
                {
                    b.HasOne("Fortes.Assess.Domain.Duration")
                        .WithMany("Questions")
                        .HasForeignKey("DurationId");

                    b.HasOne("Fortes.Assess.Domain.Level")
                        .WithMany("Questions")
                        .HasForeignKey("LevelId");

                    b.HasOne("Fortes.Assess.Domain.QuestionType")
                        .WithMany("Questions")
                        .HasForeignKey("QuestionTypeId");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.QuestionTag", b =>
                {
                    b.HasOne("Fortes.Assess.Domain.Question", "Question")
                        .WithMany("QuestionTags")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fortes.Assess.Domain.Tag", "Tag")
                        .WithMany("TagQuestions")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fortes.Assess.Domain.UserRole", b =>
                {
                    b.HasOne("Fortes.Assess.Domain.Role", "Role")
                        .WithMany("RoleUsers")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fortes.Assess.Domain.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
