using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PXLIDCardV2.domain;
using PXLIDCardV2.domain.Evaluations;
using PXLIDCardV2.domain.Users;
using System;

namespace PXLIDCardV2.data
{
    public class Context : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Lector> Lectors { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<StudentEvaluation> StudentEvaluations { get; set; }

        public Context(DbContextOptions options) : base(options) { }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Student
            modelBuilder.Entity<Student>()
                .Property("FirstName").IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Student>()
                .Property("LastName").IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Student>()
                .Property("Email").IsRequired();
            modelBuilder.Entity<Student>()
                .Property("Password").IsRequired();
            modelBuilder.Entity<Student>().HasKey(nameof(Student.Id));
            modelBuilder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1000,
                    FirstName = "Jeff",
                    LastName = "Willen",
                    Email = "jeff.willen@student.pxl.be",
                    Password = "123456"
                },

                new Student
                {
                    Id = 1001,
                    FirstName = "Sigrid",
                    LastName = "Meesters",
                    Email = "sigrid.meesters@student.pxl.be",
                    Password = "123456"
                });



            //Lector
            modelBuilder.Entity<Lector>()
               .Property("FirstName").IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Lector>()
                .Property("LastName").IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Lector>()
                .Property("Email").IsRequired();
            modelBuilder.Entity<Lector>()
                .Property("Password").IsRequired();
            modelBuilder.Entity<Lector>().HasKey(nameof(Lector.Id));
            modelBuilder.Entity<Lector>().HasData(
                new Lector
                {
                    Id = 2000,
                    FirstName = "Kris",
                    LastName = "Hermans",
                    Email = "kris.hermans@lector.pxl.be",
                    Password = "123456"
                },

                new Lector
                {
                    Id = 2001,
                    FirstName = "Tom",
                    LastName = "Schuyten",
                    Email = "tom.schuyten@lector.pxl.be",
                    Password = "123456"
                });


            //Admin
            modelBuilder.Entity<Admin>()
                .Property("FirstName").IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Admin>()
                .Property("LastName").IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Admin>()
                .Property("Email").IsRequired();
            modelBuilder.Entity<Admin>()
                .Property("Password").IsRequired();
            modelBuilder.Entity<Admin>().HasKey(nameof(Admin.Id));
            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 3000,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@admin.pxl.be",
                    Password = "123456"
                },

                new Admin
                {
                    Id = 3001,
                    FirstName = "Jane",
                    LastName = "Doe",
                    Email = "jane.doe@admin.pxl.be",
                    Password = "123456"
                });




            //Courses
            modelBuilder.Entity<Course>()
                .Property("Name").IsRequired().HasMaxLength(30);
            modelBuilder.Entity<Course>().HasKey(nameof(Course.Id));
            modelBuilder.Entity<Course>().HasData(
                new Course
                {
                    Id = 5000,
                    Name = ".NET Expert"
                },

                new Course
                {
                    Id = 5001,
                    Name = "Java Expert"
                });


            //Evaluations
            modelBuilder.Entity<Evaluation>()
                .Property("EvaluationType").IsRequired();
            modelBuilder.Entity<Evaluation>().HasKey(nameof(Evaluation.Id));
            modelBuilder.Entity<Evaluation>().HasData(
                new Evaluation
                {
                    Id = 6000,
                    LectorId = 2000,
                    CourseId = 5000,
                    EvaluationType = EvaluationType.Exam
                },

                new Evaluation
                {
                    Id = 6001,
                    LectorId = 2001,
                    CourseId = 5001,
                    EvaluationType = EvaluationType.PE_Moment
                }
                );





            //StudentEvaluations
            modelBuilder.Entity<StudentEvaluation>().HasKey(s => new { s.StudentId, s.EvaluationId });
            modelBuilder.Entity<StudentEvaluation>().HasData(
               new StudentEvaluation
               {
                   StudentId = 1000,
                   EvaluationId = 6000
               },
               new StudentEvaluation
               {
                   StudentId = 1000,
                   EvaluationId = 6001
               },
               new StudentEvaluation
               {
                   StudentId = 1001,
                   EvaluationId = 6000
               }
               );
        }

    }
}
