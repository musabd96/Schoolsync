using Domain.Models.Classrooms;

namespace Infrastructure.Repositories.Classrooms
{
    public interface IClassroomRepository
    {
        Task<List<Classroom>> GetAllClassrooms(CancellationToken cancellationToken);
    }
}
