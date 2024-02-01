using Domain.Models.Course;
using MediatR;

namespace Application.Queries.Courses.GetAllCourses
{
    public class GetAllCourseQuery : IRequest<List<Course>>
    {
    }
}
