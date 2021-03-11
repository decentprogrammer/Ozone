﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Ozone.DAL;

namespace Ozone.DAL.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210225204318_IsDeletedAdded")]
    partial class IsDeletedAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Ozone.Models.ChecklistCategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GuidId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HelpId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("PublicVisible")
                        .HasColumnType("bit");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("UnitChecklistId")
                        .HasColumnType("int");

                    b.Property<int?>("UnitChecklistModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UnitChecklistModelId");

                    b.ToTable("ChecklistCategoriesTable");
                });

            modelBuilder.Entity("Ozone.Models.ChecklistElementDetailModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActionOther")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ActionType")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ChecklistElementModelId")
                        .HasColumnType("int");

                    b.Property<Guid>("ElementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmployeesInvolved")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndEventDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndEventHour")
                        .HasColumnType("datetime2");

                    b.Property<string>("FaultDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaultOther")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FaultRank")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("FaultType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("FinalStatus")
                        .HasColumnType("bit");

                    b.Property<Guid>("GuidId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("LastMINT")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NextMINT")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PublicVisible")
                        .HasColumnType("bit");

                    b.Property<string>("ResponseDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartEventDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartEventHour")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid>("UnitGuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ChecklistElementModelId");

                    b.ToTable("ChecklistElementDetailsTable");
                });

            modelBuilder.Entity("Ozone.Models.ChecklistElementModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("CartegoryId")
                        .HasColumnType("int");

                    b.Property<int?>("ChecklistCategoryModelId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ElementRank")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid>("GuidId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HelpId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Installed")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("ProcessStatus")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("PublicVisible")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Replace")
                        .HasColumnType("datetime2");

                    b.Property<string>("RoomNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("VendorId")
                        .HasColumnType("int");

                    b.Property<string>("VendorName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.HasIndex("ChecklistCategoryModelId");

                    b.ToTable("ChecklistElementsTable");
                });

            modelBuilder.Entity("Ozone.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.HasKey("CourseId");

                    b.ToTable("Course", "Trainings");
                });

            modelBuilder.Entity("Ozone.Models.Gender", b =>
                {
                    b.Property<int>("GenderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("GenderId");

                    b.ToTable("Gender", "Catalogue");
                });

            modelBuilder.Entity("Ozone.Models.Grade", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("GradeId");

                    b.ToTable("Grade", "Catalogue");
                });

            modelBuilder.Entity("Ozone.Models.Trainee", b =>
                {
                    b.Property<int>("TraineeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DoB")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("GenderId")
                        .HasColumnType("int");

                    b.Property<int>("GradeId")
                        .HasColumnType("int");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.HasKey("TraineeId");

                    b.HasIndex("GenderId");

                    b.HasIndex("GradeId");

                    b.ToTable("Trainee", "Trainings");
                });

            modelBuilder.Entity("Ozone.Models.TraineeTraining", b =>
                {
                    b.Property<int>("TraineeId")
                        .HasColumnType("int");

                    b.Property<int>("TrainingId")
                        .HasColumnType("int");

                    b.HasKey("TraineeId", "TrainingId");

                    b.HasIndex("TrainingId");

                    b.ToTable("TraineeTraining", "Trainings");
                });

            modelBuilder.Entity("Ozone.Models.Trainer", b =>
                {
                    b.Property<int>("TrainerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Address2")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("CellNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrainingId")
                        .HasColumnType("int");

                    b.HasKey("TrainerId");

                    b.HasIndex("TrainingId");

                    b.ToTable("Trainer", "Trainings");
                });

            modelBuilder.Entity("Ozone.Models.Training", b =>
                {
                    b.Property<int>("TrainingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("TrainingId");

                    b.HasIndex("CourseId");

                    b.ToTable("Training", "Trainings");
                });

            modelBuilder.Entity("Ozone.Models.UnitCategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("CategoryNameExpr")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int?>("UnitModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UnitModelId");

                    b.ToTable("UnitCategoryTable");
                });

            modelBuilder.Entity("Ozone.Models.UnitChecklistModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GeneralStatus")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid>("GuidId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("PublicVisible")
                        .HasColumnType("bit");

                    b.Property<int>("UnitID")
                        .HasColumnType("int");

                    b.Property<int?>("UnitModelId")
                        .HasColumnType("int");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UnitModelId");

                    b.ToTable("UnitChecklistTable");
                });

            modelBuilder.Entity("Ozone.Models.UnitModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArabicName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Category")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("EnglishName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Fax")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("InternalTel_1")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("InternalTel_2")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Mobile")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("NameAbbreviation")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("ParentName")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("PersonToCantact")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ResponsibleName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Telephone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<Guid>("UnitGuId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("UnitsTable");
                });

            modelBuilder.Entity("Ozone.Models.VendorDictionaryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Email")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Fax")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Mobile")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("ProductAndService")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Tel")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("VendorName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.HasKey("Id");

                    b.ToTable("VendorsDictionaryTable");
                });

            modelBuilder.Entity("Ozone.Models.ApplicationUserModel", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CivilId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OrgzCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Role")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<Guid>("UnitGuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("ApplicationUserModel");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ozone.Models.ChecklistCategoryModel", b =>
                {
                    b.HasOne("Ozone.Models.UnitChecklistModel", "UnitChecklistModel")
                        .WithMany("ChecklistCategoriesModel")
                        .HasForeignKey("UnitChecklistModelId");

                    b.Navigation("UnitChecklistModel");
                });

            modelBuilder.Entity("Ozone.Models.ChecklistElementDetailModel", b =>
                {
                    b.HasOne("Ozone.Models.ChecklistElementModel", "ChecklistElementModel")
                        .WithMany("ChecklistElementDetailsModel")
                        .HasForeignKey("ChecklistElementModelId");

                    b.Navigation("ChecklistElementModel");
                });

            modelBuilder.Entity("Ozone.Models.ChecklistElementModel", b =>
                {
                    b.HasOne("Ozone.Models.ChecklistCategoryModel", "ChecklistCategoryModel")
                        .WithMany("ChecklistElementsModel")
                        .HasForeignKey("ChecklistCategoryModelId");

                    b.Navigation("ChecklistCategoryModel");
                });

            modelBuilder.Entity("Ozone.Models.Trainee", b =>
                {
                    b.HasOne("Ozone.Models.Gender", "Gender")
                        .WithMany("Trainees")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ozone.Models.Grade", "Grade")
                        .WithMany("Trainees")
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");

                    b.Navigation("Grade");
                });

            modelBuilder.Entity("Ozone.Models.TraineeTraining", b =>
                {
                    b.HasOne("Ozone.Models.Trainee", "Trainee")
                        .WithMany("TraineeTrainings")
                        .HasForeignKey("TraineeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ozone.Models.Training", "Training")
                        .WithMany("TraineeTrainings")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trainee");

                    b.Navigation("Training");
                });

            modelBuilder.Entity("Ozone.Models.Trainer", b =>
                {
                    b.HasOne("Ozone.Models.Training", "Training")
                        .WithMany("Trainers")
                        .HasForeignKey("TrainingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Training");
                });

            modelBuilder.Entity("Ozone.Models.Training", b =>
                {
                    b.HasOne("Ozone.Models.Course", "Course")
                        .WithMany("Trainings")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Ozone.Models.UnitCategoryModel", b =>
                {
                    b.HasOne("Ozone.Models.UnitModel", null)
                        .WithMany("UnitCategories")
                        .HasForeignKey("UnitModelId");
                });

            modelBuilder.Entity("Ozone.Models.UnitChecklistModel", b =>
                {
                    b.HasOne("Ozone.Models.UnitModel", "UnitModel")
                        .WithMany()
                        .HasForeignKey("UnitModelId");

                    b.Navigation("UnitModel");
                });

            modelBuilder.Entity("Ozone.Models.ChecklistCategoryModel", b =>
                {
                    b.Navigation("ChecklistElementsModel");
                });

            modelBuilder.Entity("Ozone.Models.ChecklistElementModel", b =>
                {
                    b.Navigation("ChecklistElementDetailsModel");
                });

            modelBuilder.Entity("Ozone.Models.Course", b =>
                {
                    b.Navigation("Trainings");
                });

            modelBuilder.Entity("Ozone.Models.Gender", b =>
                {
                    b.Navigation("Trainees");
                });

            modelBuilder.Entity("Ozone.Models.Grade", b =>
                {
                    b.Navigation("Trainees");
                });

            modelBuilder.Entity("Ozone.Models.Trainee", b =>
                {
                    b.Navigation("TraineeTrainings");
                });

            modelBuilder.Entity("Ozone.Models.Training", b =>
                {
                    b.Navigation("TraineeTrainings");

                    b.Navigation("Trainers");
                });

            modelBuilder.Entity("Ozone.Models.UnitChecklistModel", b =>
                {
                    b.Navigation("ChecklistCategoriesModel");
                });

            modelBuilder.Entity("Ozone.Models.UnitModel", b =>
                {
                    b.Navigation("UnitCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
