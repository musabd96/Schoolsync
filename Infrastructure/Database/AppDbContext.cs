using Domain.Models.Classrooms;
using Domain.Models.Course;
using Domain.Models.Student;
using Domain.Models.Teacher;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Classroom> Classrooms { get; set; }
        public virtual DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DbSeed.DbSeed.SeedStudents(modelBuilder);
            DbSeed.DbSeed.SeedTeachers(modelBuilder);
            DbSeed.DbSeed.SeedUsers(modelBuilder);
            DbSeed.DbSeed.SeedClassrooms(modelBuilder);
            DbSeed.DbSeed.SeedCourses(modelBuilder);
        }
    }
}
