using System.Threading;
using System.Threading.Tasks;
using Application.Commands.Classrooms.AddClassroom;
using Domain.Models.Classrooms;
using MediatR;
using Infrastructure.Repositories.Classrooms;

namespace Application.Commands.Classrooms.AddClassroom
{
    public class AddClassroomCommandHandler : IRequestHandler<AddClassroomCommand, Classroom>
    {
        private readonly IClassroomRepository _classroomRepository;

        public AddClassroomCommandHandler(IClassroomRepository classroomRepository)
        {
            _classroomRepository = classroomRepository;
        }

        public async Task<Classroom> Handle(AddClassroomCommand request, CancellationToken cancellationToken)
        {
            // Create a new classroom
            var newClassroom = new Classroom
            {
                Id = Guid.NewGuid(),
                ClassroomName = request.Classroom.ClassroomName
                // Set other properties as needed
            };

            await _classroomRepository.AddClassroom(newClassroom, cancellationToken);

            return newClassroom;
        }
    }
}
