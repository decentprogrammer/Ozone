﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ozone.Models;

namespace Ozone.DAL
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Video>()
                .HasOne<Course>(s => s.Course)
                .WithMany(g => g.Videos)
                .HasForeignKey(s => s.CourseId);

            modelBuilder.Entity<TraineeTraining>().HasKey(tt => new { tt.TraineeId, tt.TrainingId });

            modelBuilder.Entity<TraineeTraining>()
                .HasOne<Trainee>(t => t.Trainee)
                .WithMany(tc => tc.TraineeTrainings)
                .HasForeignKey(t => t.TraineeId);


            modelBuilder.Entity<TraineeTraining>()
                .HasOne<Training>(c => c.Training)
                .WithMany(tc => tc.TraineeTrainings)
                .HasForeignKey(c => c.TrainingId);            

            modelBuilder.Entity<TrainerTraining>().HasKey(tt => new { tt.TrainerId, tt.TrainingId });

            modelBuilder.Entity<TrainerTraining>()
                .HasOne<Trainer>(t => t.Trainer)
                .WithMany(tc => tc.TrainerTrainings)
                .HasForeignKey(t => t.TrainerId);

            modelBuilder.Entity<TrainerTraining>()
                .HasOne<Training>(c => c.Training)
                .WithMany(tc => tc.TrainerTrainings)
                .HasForeignKey(c => c.TrainingId);
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Trainee> Trainees { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Division> Divisions { get; set; }
        public DbSet<TrainerTraining> TrainerTrainings { get; set; }
        public DbSet<TraineeTraining> TraineeTrainings { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<UnitModel> UnitsTable { get; set; }
        public DbSet<UnitChecklistModel> UnitChecklistTable { get; set; }
        public DbSet<ChecklistCategoryModel> ChecklistCategoriesTable { get; set; }
        public DbSet<ChecklistElementModel> ChecklistElementsTable { get; set; }
        public DbSet<ChecklistElementDetailModel> ChecklistElementDetailsTable { get; set; }
        public DbSet<UnitCategoryModel> UnitCategoryTable { get; set; }
        public DbSet<ApplicationUserModel> ApplicationUsersTable { get; set; }
        public DbSet<VendorDictionaryModel> VendorsDictionaryTable { get; set; }
    }
}
