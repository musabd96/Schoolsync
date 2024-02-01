using Application.Commands.Classrooms.DeleteClassroom;
using Domain.Models.Classrooms;
using Infrastructure.Repositories.Classrooms;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Classrooms.DeleteClassroom
{
    public class DeleteClassroomCommandHandler : IRequestHandler<DeleteClassroomCommand, Classroom>
    {
        private readonly IClassroomRepository _classroomRepository;

        public DeleteClassroomCommandHandler(IClassroomRepository classroomRepository)
        {
            _classroomRepository = classroomRepository;
        }

        public async Task<Classroom> Handle(DeleteClassroomCommand request, CancellationToken cancellationToken)
        {
            var classroomToDelete = await _classroomRepository.DeleteClassroom(request.ClassroomId, cancellationToken);

            return classroomToDelete;
        }
    }
}
