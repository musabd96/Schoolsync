using Domain.Models.Teacher;
using Infrastructure.Repositories.Teachers;
using MediatR;

namespace Application.Commands.Teachers.DeleteTeacher
{
    public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand, Teacher>
    {
        private readonly ITeacherRepository _teacherRepository;

        public DeleteTeacherCommandHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public Task<Teacher> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacherToDelete = _teacherRepository.DeleteTeacher(request.TeacherId, cancellationToken);

            return teacherToDelete;
        }
    }
}
