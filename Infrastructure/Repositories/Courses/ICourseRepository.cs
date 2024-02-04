using Domain.Models.Course;

namespace Infrastructure.Repositories.Courses
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllCoursesAsync(CancellationToken cancellationToken);
        Task<Course> UpdateCourse(Guid id, string CourseName, CancellationToken cancellationToken);
        Task<Course> DeleteCourse(Guid id, CancellationToken cancellationToken);
    }
}
