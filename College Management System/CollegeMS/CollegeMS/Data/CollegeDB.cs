using Microsoft.EntityFrameworkCore;
using CollegeMS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CollegeMS.Data
{
    public class CollegeDB : IdentityDbContext<ApplicationUser>
    {
        public CollegeDB(){ }
        public CollegeDB(DbContextOptions<CollegeDB> options): base(options)
        {

        }
        // for edit Models constrains
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Make Primary Key Constrain On StudentCourses Model

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StudentCourses>().HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourses>()
                 .HasOne<Student>(sc => sc.Student)
                 .WithMany(s => s.StudentCourses)
                 .HasForeignKey(sc => sc.StudentId);


            modelBuilder.Entity<StudentCourses>()
                 .HasOne<Course>(sc => sc.Course)
                 .WithMany(c => c.StudentCourses)
                 .HasForeignKey(sc => sc.CourseId);

            #endregion
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<StudentCourses> StudentCourses { get; set; }

    }

    
}
