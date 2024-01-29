using Application.Dtos;
using Domain.Models.Classrooms;
using MediatR;

namespace Application.Commands.Classrooms.UpdateClassroom
{
    public class UpdateClassroomCommand : IRequest<Classroom>
    {
        public UpdateClassroomCommand(ClassroomDto updatedClassroom, Guid id)
        {
            UpdatedClassroom = updatedClassroom;
            Id = id;
        }

        public ClassroomDto UpdatedClassroom { get; set; }
        public Guid Id { get; set; }
    }
}
