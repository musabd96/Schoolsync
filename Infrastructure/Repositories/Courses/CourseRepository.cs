using Domain.Models.Course;
using Domain.Models.Teacher;
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

        public Task<Course> UpdateCourse(Guid id, string CourseName, CancellationToken cancellationToken)
        {
            try
            {
                Course couseToUpdate = _appDbContext.Courses.FirstOrDefault(c => c.Id == id)!;

                if (couseToUpdate != null)
                {
                    couseToUpdate.CourseName = CourseName;
                }

                _appDbContext.Update(couseToUpdate!);
                _appDbContext.SaveChangesAsync(cancellationToken);
                return Task.FromResult(couseToUpdate)!;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating a couse with ID {id} in the database", ex);
            }
        }
    }
}
        public async Task<Course> DeleteCourse(Guid courseId, CancellationToken cancellationToken)
        {
            try
            {
                var courseToDelete = await _appDbContext.Course.FirstOrDefaultAsync(c => c.Id == courseId, cancellationToken);

                if (courseToDelete != null)
                {
                    _appDbContext.Remove(courseToDelete);
                    await _appDbContext.SaveChangesAsync(cancellationToken);
                }

                return courseToDelete;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting a course with ID {courseId} from the database", ex);
            }
        }

    }
}