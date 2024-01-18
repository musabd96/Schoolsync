
using Domain.Models.Student;
using Infrastructure.Database;

namespace Infrastructure.Repositories.Students
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _appDbContext;
        public StudentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task<List<Student>> GetAllStudent(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetStudentById(Guid id, CancellationToken cancellationToken)
        {
            Student student = _appDbContext.Student.FirstOrDefault(s => s.Id == id)!;

            return Task.FromResult(student);
        }

        public Task<Student> AddStudent(Student newStudent, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Student> UpdateStudent(Guid id, string FirstName, string LastName, DateTime DateOfBirth, string Address, string PhoneNumber, string Email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Student> DeleteStudent(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
