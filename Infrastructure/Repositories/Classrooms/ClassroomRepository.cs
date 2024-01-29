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
    }
}
