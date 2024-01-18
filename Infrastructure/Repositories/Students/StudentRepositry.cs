
using Domain.Models.Student;

namespace Infrastructure.Repositories.Students
{
    public class StudentRepositry : IStudentRepositry
    {
        public Task<Student> AddStudent(Student newStudent, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Student> DeleteStudent(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<Student>> GetAllStudent(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetStudentById(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Student> UpdateStudent(Guid id, string FirstName, string LastName, DateTime DateOfBirth, string Address, string PhoneNumber, string Email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
