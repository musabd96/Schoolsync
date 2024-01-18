using Domain.Models.Student;
using MediatR;

namespace Application.Queries.Students.GetAllStudents
{
    public class GetAllStudentsQuery : IRequest<List<StudentModel>>
    {
    }
}
