using System;
using Domain.Models.Classrooms;
using MediatR;

namespace Application.Commands.Classrooms.DeleteClassroom
{
    public class DeleteClassroomCommand : IRequest<Classroom>
    {
        public DeleteClassroomCommand(Guid classroomId)
        {
            ClassroomId = classroomId;
        }

        public Guid ClassroomId { get; }
    }
}
