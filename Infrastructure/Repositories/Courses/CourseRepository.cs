using Domain.Models.Course;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Courses
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _appDbContext;
        public CourseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<Course>> GetAllCoursesAsync(CancellationToken cancellationToken)
        {
            return await _appDbContext.Courses.ToListAsync();
        }

        public Task<Course> GetCourseById(Guid id, CancellationToken cancellationToken)
        {
            Course course = _appDbContext.Courses.FirstOrDefault(c => c.Id == id)!;

            return Task.FromResult(course);
        }
    }
}
