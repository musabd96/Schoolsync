
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
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed students and teachers

            DbSeed.DbSeed.SeedStudents(modelBuilder);
            DbSeed.DbSeed.SeedTeachers(modelBuilder);
            DbSeed.DbSeed.SeedUsers(modelBuilder);
        }
    }
}
