
using Domain.Models.Student;
using Domain.Models.Teacher;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class AppDbContext : DbContext
    {

        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public static DbSet<Student> Students { get; set; }
        public static DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=Schoolsync;User=root;Password=mamamia;"
                                        , new MySqlServerVersion(new Version(8, 0, 35)));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed students and teachers

            DbSeed.DbSeed.SeedStudents(modelBuilder);
            DbSeed.DbSeed.SeedTeachers(modelBuilder);
        }
    }
}
