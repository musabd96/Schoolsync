

using Domain.Models.Teacher;
using Infrastructure.Database;

namespace Infrastructure.Repositories.Teachers
{
    public class TeacherRepository : ITeacherRepository
    {

        private readonly AppDbContext _appDbContext;
        public TeacherRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Task<Teacher> AddTeacher(Teacher newTeacher, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Teacher> DeleteTeacher(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<Teacher>> GetAllTeacher(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Teacher> GetTeacherById(Guid id,CancellationToken cancellationToken)
        {
            return await _appDbContext.Teacher.FindAsync(id);
        }

        public Task<Teacher> UpdateTeacher(Guid id, string FirstName, string LastName, DateTime DateOfBirth, string Address, string PhoneNumber, string Email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
