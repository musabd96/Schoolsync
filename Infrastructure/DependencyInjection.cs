using Infrastructure.Repositories.Students;
using Infrastructure.Repositories.Teachers;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepositry, StudentRepositry>();
            services.AddScoped<ITeacherRepositry, TeacherRepositry>();
            return services;
        }
    }
}
