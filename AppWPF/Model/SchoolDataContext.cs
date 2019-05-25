using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AppWPF.Model
{
    public class SchoolDataContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<OnlineCourse> OnlineCourses { get; set; }
        public DbSet<OnsiteCourse> OnsiteCourses { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<OfficeAssignment> OfficeAsigments { get; set; }
        public DbSet<StudentGrade> StudentGrades { get; set; }
        public DbSet<CourseInstructor> CourseInstructors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Department>()
                .ToTable("Department")
                .HasKey(d => new { d.DepartmentID})
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(128);

            modelBuilder.Entity<Course>()
                .ToTable("Course")
                .HasKey(c => new { c.CourseID });
            modelBuilder.Entity<Course>()
                .HasRequired(c => c.OnlineCourse)
                .WithRequiredPrincipal(c => c.Course);
            modelBuilder.Entity<Course>()
                .HasRequired(c => c.OnsiteCourse)
                .WithRequiredPrincipal(c => c.Course);

            modelBuilder.Entity<OnlineCourse>()
                .ToTable("OnlineCourse")
                .HasKey(o => new { o.CourseID })
                .Property(o => o.URL)
                .IsRequired();

            modelBuilder.Entity<OnsiteCourse>()
                .ToTable("OnsiteCourse")
                .HasKey(o => new { o.CourseID})
                .Property(o => o.Location)
                .IsRequired();

            modelBuilder.Entity<Person>()
                .ToTable("Person")
                .HasKey(p => new { p.PersonID });
            modelBuilder.Entity<Person>()
                .HasRequired(p => p.OfficeAsigment)
                .WithRequiredPrincipal(p => p.Person);

            modelBuilder.Entity<Person>()
                .ToTable("Person").Property(p => p.Firstname).IsRequired();
            modelBuilder.Entity<Person>()
                .ToTable("Person").Property(p => p.Lastname).IsRequired();

           

            modelBuilder.Entity<StudentGrade>()
                .ToTable("StudentGrade")
                .HasKey(s => new { s.EnrollmentID });

            modelBuilder.Entity<StudentGrade>()
                .ToTable("StudentGrade")
                .HasRequired<Person>(p => p.Person)
                .WithMany(p => p.StudentGrades)
                .HasForeignKey<int>(s => s.StudentID);

            modelBuilder.Entity<OfficeAssignment>()
               .ToTable("OfficeAssigment")
               .HasKey(o => new { o.InstructorID });
            /* modelBuilder.Entity<OfficeAssignment>()
                //.ToTable("OfficeAssigment")
                .HasRequired(p => p.Person)
                .WithOptional(p => p.OfficeAsigment)
                .Map(o => o.MapKey("InstructorID"));
            */

            modelBuilder.Entity<CourseInstructor>()
                .ToTable("CourseInstructor")
                .HasKey(c => new { c.CourseID, c.PersonID });



        }
    }
}
