using Domain.Models.Classrooms;
using Infrastructure.Repositories.Classrooms;
using MediatR;

namespace Application.Queries.Classrooms.GetClassroomsById
{
    public class GetClassroomByIdQueryHandler : IRequestHandler<GetClassroomByIdQuery, Classroom>
    {
        private readonly IClassroomRepository _classroomRepository;

        public GetClassroomByIdQueryHandler(IClassroomRepository classroomRepository)
        {
            _classroomRepository = classroomRepository;
        }

        public async Task<Classroom> Handle(GetClassroomByIdQuery request, CancellationToken cancellationToken)
        {
            Classroom wantedClassroom = await _classroomRepository.GetClassroomById(request.Id, cancellationToken);

            try
            {
                if (wantedClassroom == null)
                {
                    return null!;
                }
                return wantedClassroom;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}