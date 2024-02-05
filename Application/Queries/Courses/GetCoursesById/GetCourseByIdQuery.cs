using Domain.Models.Course;
using MediatR;

namespace Application.Queries.Courses.GetCoursesById
{
    public class GetCourseByIdQuery : IRequest<Course>
    {
        public GetCourseByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
