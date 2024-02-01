using Domain.Models.Classrooms;
using Domain.Models.Student;
using Domain.Models.Teacher;

namespace Infrastructure.Repositories.Classrooms
{
    public interface IClassroomRepository
    {
        Task<List<Classroom>> GetAllClassrooms(CancellationToken cancellationToken);

        Task<Classroom> AddClassroom(Classroom newClassroom, CancellationToken cancellationToken);
        Task<Classroom> UpdateClassroom(Guid id, string ClassroomName, CancellationToken cancellationToken);
        Task<Classroom> DeleteClassroom(Guid id, CancellationToken cancellationToken);
    }
}
