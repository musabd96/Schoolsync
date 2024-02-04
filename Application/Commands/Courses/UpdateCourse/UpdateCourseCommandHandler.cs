

using Domain.Models.Course;
using Infrastructure.Repositories.Courses;
using MediatR;

namespace Application.Commands.Courses.UpdateCourse
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, Course>
    {
        private readonly ICourseRepository _courseRepository;

        public UpdateCourseCommandHandler(ICourseRepository studentRepository)
        {
            _courseRepository = studentRepository;
        }
        public async Task<Course> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var Id = request.Id;
            var CourseName = request.UpdatedCourse.CourseName;

            var courseToUpdate = await _courseRepository.UpdateCourse(Id, CourseName, cancellationToken);

            return courseToUpdate!;
        }
    }
}
