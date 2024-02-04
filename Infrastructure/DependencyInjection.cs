﻿using Infrastructure.Database;
using Infrastructure.Repositories.Classrooms;
using Infrastructure.Repositories.Courses;
using Infrastructure.Repositories.Students;
using Infrastructure.Repositories.Teachers;
using Infrastructure.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IClassroomRepository, ClassroomRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 34)));
            });
            return services;
        }
    }
}
