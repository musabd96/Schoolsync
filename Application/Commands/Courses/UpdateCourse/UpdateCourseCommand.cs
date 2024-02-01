using Application.Dtos;
using Domain.Models.Course;
using MediatR;

namespace Application.Commands.Courses.UpdateCourse
{
    public class UpdateCourseCommand : IRequest<Course>
    {
        public UpdateCourseCommand(CourseDto updatedCourse, Guid id)
        {
            Id = id;
            UpdatedCourse = updatedCourse;
        }
        public CourseDto UpdatedCourse { get; set; }
        public Guid Id { get; set; }
    }
}
