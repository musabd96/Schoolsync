using Infrastructure.Database;
using Infrastructure.Repositories.Students;
using Infrastructure.Repositories.Teachers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();

            services.AddDbContext<AppDbContext>(options =>
            {
                //connectionString to Db
                var connectionString = "Server=localhost;Port=3306;Database=API_Animals;User=root;Password=mustafa0909;";

                options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 35)));
            });
            return services;
        }
    }
}
