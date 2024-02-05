using Domain.Models.Course;
using Infrastructure.Repositories.Courses;
using MediatR;

namespace Application.Queries.Courses.GetCoursesById
{

    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, Course>
    {
        private readonly ICourseRepository _courseRepository;

        public GetCourseByIdQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<Course> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            Course wantedCourse = await _courseRepository.GetCourseById(request.Id, cancellationToken);

            try
            {
                if (wantedCourse == null)
                {
                    return null!;
                }
                return wantedCourse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
