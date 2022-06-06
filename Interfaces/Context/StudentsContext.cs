using Interfaces.Context.Models;
using Microsoft.EntityFrameworkCore;

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

            //modelBuilder.Entity<ICourse>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            //modelBuilder.Entity<IStudent>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

            modelBuilder.Entity<CourseDB>().HasKey(c => c.Id);
            modelBuilder.Entity<StudentDB>().HasKey(s => s.Id);

            modelBuilder.Entity<CourseDB>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<StudentDB>().Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<StudentDB>()
                            .HasMany(s => s.Courses.Keys)
                            .WithOne()
                            .HasForeignKey(c => c.IdStudent);

            //modelBuilder.Entity<CourseDB>()
            //                .HasOne<StudentDB>()
            //                .WithMany()
            //                .HasForeignKey(c => c.IdStudent);
        }
    }
}
