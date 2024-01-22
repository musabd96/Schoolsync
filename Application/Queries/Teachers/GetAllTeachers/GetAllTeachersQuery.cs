using Domain.Models.Teacher;
using MediatR;

namespace Application.Queries.Teachers.GetAllTeachers
{
    public class GetAllTeachersQuery : IRequest<List<Teacher>>
    {
    }
}