
using Domain.Models.Student;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Students
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _appDbContext;
        public StudentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Task<StudentModel> AddStudent(StudentModel newStudent, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<StudentModel> DeleteStudent(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<StudentModel>> GetAllStudentsAsync(CancellationToken cancellationToken)
        {
            return await _appDbContext.Student.ToListAsync();
        }

        public async Task<StudentModel> GetStudentById(Guid id, CancellationToken cancellationToken)
        {
            return await _appDbContext.Student.FindAsync(id);
        }

        public Task<StudentModel> UpdateStudent(Guid id, string FirstName, string LastName, DateTime DateOfBirth, string Address, string PhoneNumber, string Email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
