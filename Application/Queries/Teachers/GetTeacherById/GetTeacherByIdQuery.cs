using Domain.Models.Teacher;
using MediatR;

namespace Application.Queries.Teachers.GetTeacherById
{
    public class GetTeacherByIdQuery : IRequest<Teacher>
    {
        public GetTeacherByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
