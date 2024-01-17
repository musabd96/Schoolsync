
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

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=API_Animals;User=root;Password=mustafa0909;"
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
