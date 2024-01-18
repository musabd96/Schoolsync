
using Application.Dtos;
using MediatR;

namespace Application.Queries.Teachers.GetAllTeachers
{
    public class GetAllTeachersQuery : IRequest<List<TeacherDto>>
    {
        
    }
}
