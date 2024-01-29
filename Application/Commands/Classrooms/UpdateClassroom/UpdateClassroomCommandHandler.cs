using Domain.Models.Classrooms;
using Infrastructure.Repositories.Classrooms;
using Infrastructure.Repositories.Students;
using MediatR;

namespace Application.Commands.Classrooms.UpdateClassroom
{
    public class UpdateClassroomCommandHandler : IRequestHandler<UpdateClassroomCommand, Classroom>
    {
        private readonly IClassroomRepository _classroomRepository;

        public UpdateClassroomCommandHandler(IClassroomRepository classroomRepository)
        {
            _classroomRepository = classroomRepository;
        }
        public async Task<Classroom> Handle(UpdateClassroomCommand request, CancellationToken cancellationToken)
        {
            // Update the classroom details

            var Id = request.Id;
            var ClassroomName = request.UpdatedClassroom.ClassroomName;

            var classroomToUpdate = await _classroomRepository.UpdateClassroom(Id, ClassroomName, cancellationToken);

            return classroomToUpdate;
        }
    }
}
