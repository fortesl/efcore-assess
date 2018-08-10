﻿// <auto-generated />
using Fortes.Assess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Fortes.Assess.Data.Migrations
{
    [DbContext(typeof(AssessDbContext))]
    [Migration("20180808021613_assess-domain4")]
    partial class assessdomain4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fortes.Assess.Domain.AdminPage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AssessmentId");

                    b.Property<string>("Body");

                    b.Property<string>("Footer");

                    b.Property<string>("Header");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("AdminPages");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.Assessment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AdminPageId");

                    b.Property<int?>("CompanyId");

                    b.Property<string>("Description");

                    b.Property<int?>("DurationId");

                    b.Property<DateTime>("EndDate");

                    b.Property<int?>("FieldId");

                    b.Property<int?>("FrameworkId");

                    b.Property<int?>("IndustryId");

                    b.Property<DateTime>("LastModified");

                    b.Property<int?>("LevelId");

                    b.Property<string>("Name");

                    b.Property<int?>("OccupationId");

                    b.Property<int?>("PassingGrade");

                    b.Property<int?>("ProgrammingLanguageId");

                    b.Property<DateTime>("StartDate");

                    b.Property<int?>("UserPageId");

                    b.HasKey("Id");

                    b.HasIndex("AdminPageId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DurationId");

                    b.HasIndex("FieldId");

                    b.HasIndex("FrameworkId");

                    b.HasIndex("IndustryId");

                    b.HasIndex("LevelId");

                    b.HasIndex("OccupationId");

                    b.HasIndex("ProgrammingLanguageId");

                    b.HasIndex("UserPageId");

                    b.ToTable("Assessments");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.AssessmentQuestion", b =>
                {
                    b.Property<int>("AssessmentId");

                    b.Property<int>("QuestionId");

                    b.Property<DateTime>("LastModified");

                    b.HasKey("AssessmentId", "QuestionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("AssessmentQuestion");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.AssessmentUser", b =>
                {
                    b.Property<int>("AssessmentId");

                    b.Property<int>("UserId");

                    b.Property<DateTime>("LastModified");

                    b.Property<int>("RoleId");

                    b.HasKey("AssessmentId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("AssessmentUser");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("IndustryId");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("IndustryId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.Duration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Durations");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.Field", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.Framework", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Frameworks");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.Industry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Industries");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.Level", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.Occupation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Occupations");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<bool>("IsCorrect");

                    b.Property<DateTime>("LastModified");

                    b.Property<int>("QuestionId");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Option");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.ProgrammingLanguage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ProgrammingLanguages");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Description");

                    b.Property<int>("DurationId");

                    b.Property<string>("Explanation");

                    b.Property<DateTime>("LastModified");

                    b.Property<int>("LevelId");

                    b.Property<int>("QuestionTypeId");

                    b.HasKey("Id");

                    b.HasIndex("DurationId");

                    b.HasIndex("LevelId");

                    b.HasIndex("QuestionTypeId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.QuestionTag", b =>
                {
                    b.Property<int>("QuestionId");

                    b.Property<int>("TagId");

                    b.Property<DateTime>("LastModified");

                    b.HasKey("QuestionId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("QuestionTag");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.QuestionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("QuestionTypes");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CompanyId");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.UserPage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AssessmentId");

                    b.Property<string>("Body");

                    b.Property<string>("Footer");

                    b.Property<string>("Header");

                    b.Property<DateTime>("LastModified");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("UserPages");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.Property<DateTime>("LastModified");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Fortes.Assess.Domain.Assessment", b =>
                {
                    b.HasOne("Fortes.Assess.Domain.AdminPage", "AdminPage")
                        .WithMany()
                        .HasForeignKey("AdminPageId");

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
                        .HasForeignKey("UserPageId");
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
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Fortes.Assess.Domain.Question", b =>
                {
                    b.HasOne("Fortes.Assess.Domain.Duration")
                        .WithMany("Questions")
                        .HasForeignKey("DurationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fortes.Assess.Domain.Level")
                        .WithMany("Questions")
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Fortes.Assess.Domain.QuestionType")
                        .WithMany("Questions")
                        .HasForeignKey("QuestionTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
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