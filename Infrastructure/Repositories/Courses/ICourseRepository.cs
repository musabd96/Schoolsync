using Domain.Models.Course;

namespace Infrastructure.Repositories.Courses
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllCoursesAsync(CancellationToken cancellationToken);
    }
}
