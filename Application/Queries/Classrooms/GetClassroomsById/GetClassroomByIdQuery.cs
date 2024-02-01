using Domain.Models.Classrooms;
using MediatR;

namespace Application.Queries.Classrooms.GetClassroomsById
{
    public class GetClassroomByIdQuery : IRequest<Classroom>
    {
        public GetClassroomByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
