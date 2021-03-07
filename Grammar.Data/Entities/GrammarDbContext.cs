using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grammar.Data.Entities
{
    public class GrammarDbContext : DbContext
    {
        public GrammarDbContext(DbContextOptions options)
               : base(options)
        {
        }

        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<Answers> Answers { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Exercises> Exercises { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<SubCategories> SubCategories { get; set; }
        public DbSet<TeachersStudents> TeachersStudents { get; set; }
        public DbSet<Types> Types { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UsersAnswers> UsersAnswers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubCategories>()
            .HasOne(bc => bc.Category)
            .WithMany(b => b.SubCategories)
            .HasForeignKey(bc => bc.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);


         modelBuilder.Entity<Exercises>()
              .HasOne(bc => bc.Type)
              .WithMany(b => b.Exercises)
              .HasForeignKey(bc => bc.TypeId)
              .OnDelete(DeleteBehavior.Restrict);

         modelBuilder.Entity<Exercises>()
            .HasOne(bc => bc.SubCategory)
            .WithMany(b => b.Exercises)
            .HasForeignKey(bc => bc.SubCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

         modelBuilder.Entity<Questions>()
           .HasOne(bc => bc.Exercise)
           .WithMany(b => b.Questions)
           .HasForeignKey(bc => bc.ExerciseId)
           .OnDelete(DeleteBehavior.Restrict);

         modelBuilder.Entity<Answers>()
           .HasOne(bc => bc.Question)
           .WithMany(b => b.Answers)
           .HasForeignKey(bc => bc.QuestionId)
           .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<UsersAnswers>()
          .HasOne(bc => bc.Question)
          .WithMany(b => b.UsersAnswers)
          .HasForeignKey(bc => bc.QuestionId)
          .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<UsersAnswers>()
            .HasOne(bc => bc.User)
            .WithMany(b => b.UsersAnswers)
            .HasForeignKey(bc => bc.UserId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsersAnswers>()
              .HasOne(bc => bc.Answer)
              .WithMany(b => b.UsersAnswers)
              .HasForeignKey(bc => bc.AnswerId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsersAnswers>()
            .HasOne(bc => bc.SubCategory)
            .WithMany(b => b.UsersAnswers)
            .HasForeignKey(bc => bc.SubCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsersAnswers>()
             .HasOne(bc => bc.Category)
             .WithMany(b => b.UsersAnswers)
             .HasForeignKey(bc => bc.CategoryId)
             .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Users>()
               .HasOne(bc => bc.Role)
               .WithMany(b => b.Users)
               .HasForeignKey(bc => bc.RoleId)
               .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TeachersStudents>()
              .HasOne(bc => bc.Student)
              .WithMany(b => b.StudentsTeachers)
              .HasForeignKey(bc => bc.StudentId)
              .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TeachersStudents>()
                .HasOne(bc => bc.Teacher)
                .WithMany(b => b.TeachersStudents)
                .HasForeignKey(bc => bc.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
