using Application.Dtos;
using Domain.Models.Teacher;
using MediatR;

namespace Application.Commands.Teachers.UpdateTeacher
{
    public class UpdateTeacherCommand : IRequest<Teacher>
    {
        public UpdateTeacherCommand(TeacherDto updatedTeacher, Guid id)
        {
            Id = id;
            UpdatedTeacher = updatedTeacher;
        }
        public TeacherDto UpdatedTeacher { get; set; }
        public Guid Id { get; set; }
    }
}
