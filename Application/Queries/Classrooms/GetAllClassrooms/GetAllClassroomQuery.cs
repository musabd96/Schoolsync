using Domain.Models.Classrooms;
using MediatR;

namespace Application.Queries.Classrooms.GetAllClassrooms
{
    public class GetAllClassroomQuery : IRequest<List<Classroom>>
    {
    }
}
