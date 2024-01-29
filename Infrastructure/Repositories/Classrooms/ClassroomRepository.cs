using Domain.Models.Classrooms;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Classrooms
{
    public class ClassroomRepository : IClassroomRepository
    {
        private readonly AppDbContext _appDbContext;
        public ClassroomRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Classroom>> GetAllClassrooms(CancellationToken cancellationToken)
        {
            return await _appDbContext.Classrooms.ToListAsync(cancellationToken);
        }

        public async Task<Classroom> UpdateClassroom(Guid Id, string ClassroomName, CancellationToken cancellationToken)
        {
            Classroom classroomToUpdate = await _appDbContext.Classrooms.FirstOrDefaultAsync(cr => cr.Id == Id);
            if (classroomToUpdate == null)
            {
                return null!;
            }

            // Update the classroom details
            classroomToUpdate.ClassroomName = ClassroomName;

            _appDbContext.Classrooms.Update(classroomToUpdate);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return classroomToUpdate;
        }
    }
}
