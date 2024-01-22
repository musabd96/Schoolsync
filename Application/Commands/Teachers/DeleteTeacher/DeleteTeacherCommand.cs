using Domain.Models.Teacher;
using MediatR;

namespace Application.Commands.Teachers.DeleteTeacher
{
    public class DeleteTeacherCommand : IRequest<Teacher>
    {
        public DeleteTeacherCommand(Guid teacherId)
        {
            TeacherId = teacherId;
        }
        public Guid TeacherId { get; set; }
    }
}
