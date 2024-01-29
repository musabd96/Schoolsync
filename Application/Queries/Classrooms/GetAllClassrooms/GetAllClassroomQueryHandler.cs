using Domain.Models.Classrooms;
using Infrastructure.Repositories.Classrooms;
using MediatR;

namespace Application.Queries.Classrooms.GetAllClassrooms
{
    public class GetAllClassroomQueryHandler : IRequestHandler<GetAllClassroomQuery, List<Classroom>>
    {
        private readonly IClassroomRepository _classroomRepository;

        public GetAllClassroomQueryHandler(IClassroomRepository classroomRepository)
        {
            _classroomRepository = classroomRepository;
        }

        public async Task<List<Classroom>> Handle(GetAllClassroomQuery request, CancellationToken cancellationToken)
        {
            List<Classroom> allClassrooms = await _classroomRepository.GetAllClassrooms(cancellationToken);
            return allClassrooms ?? throw new InvalidOperationException("No classrooms were found");
        }
    }
}