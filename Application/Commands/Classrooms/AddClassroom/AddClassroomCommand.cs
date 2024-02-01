using Application.Dtos;
using Domain.Models.Classrooms;
using MediatR;
using System;

namespace Application.Commands.Classrooms.AddClassroom
{
    public class AddClassroomCommand : IRequest<Classroom>
    {
        public AddClassroomCommand(ClassroomDto classroom)
        {
            Classroom = classroom;
        }

        public ClassroomDto Classroom { get; set; }
    }
}
