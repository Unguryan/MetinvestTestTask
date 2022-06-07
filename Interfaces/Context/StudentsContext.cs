using Interfaces.Context.Models;
using Interfaces.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Interfaces.Context
{
    public class StudentsContext : DbContext
    {
        public StudentsContext(DbContextOptions<StudentsContext> options) : base(options)
        {

        }

        public DbSet<CourseDB> Courses { get; set; }

        public DbSet<StudentDB> Students  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseDB>().ToTable("Courses");
            modelBuilder.Entity<StudentDB>().ToTable("Students");

            modelBuilder.Entity<CourseDB>().HasKey(x => x.Id);
            modelBuilder.Entity<StudentDB>().HasKey(x => x.Id);

            modelBuilder.Entity<CourseDB>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<StudentDB>().Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<StudentDB>()
            .Property(x => x.Vacations)
            .HasConversion(
                x => JsonConvert.SerializeObject(x),
                x => JsonConvert.DeserializeObject<IDictionary<int, IDictionary<DateTime, DateTime>>>(x));

            modelBuilder.Entity<CourseStudentDB>()
                .HasKey(x => new { x.StudentId, x.CourseId });

            modelBuilder.Entity<CourseStudentDB>()
                .HasOne(x => x.Student)
                .WithMany(y => y.Courses)
                .HasForeignKey(y => y.StudentId);

            modelBuilder.Entity<CourseStudentDB>()
                .HasOne(x => x.Course)
                .WithMany(y => y.Students)
                .HasForeignKey(y => y.CourseId);
        }
    }
}
