using Application.Dtos;
using Domain.Models.Teacher;
using MediatR;
using System;

namespace Application.Commands.Teachers.AddTeacher
{
    public class AddTeacherCommand : IRequest<Teacher>
    {
        public AddTeacherCommand(TeacherDto teacher)
        {
            Teacher = teacher;
        }
        public TeacherDto Teacher { get; set; }
    }
}
