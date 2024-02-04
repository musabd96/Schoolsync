using Domain.Models.Course;
using Infrastructure.Repositories.Courses;
using MediatR;

namespace Application.Queries.Courses.GetAllCourses
{
    public class GetAllCourseQueryHandler : IRequestHandler<GetAllCourseQuery, List<Course>>
    {
        private readonly ICourseRepository _courseRepository;

        public GetAllCourseQueryHandler(ICourseRepository studentRepository)
        {
            _courseRepository = studentRepository;
        }
        public async Task<List<Course>> Handle(GetAllCourseQuery request, CancellationToken cancellationToken)
        {
            List<Course> allCoursesFromDatabase = await _courseRepository.GetAllCoursesAsync(cancellationToken);
            if (allCoursesFromDatabase == null)
            {
                throw new InvalidOperationException("No Course was Found");

            }

            return allCoursesFromDatabase;
        }
    }
}
