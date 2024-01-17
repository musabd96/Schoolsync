using Domain.Models.Student;

namespace Infrastructure.Repositories.Students
{
    public interface IStudentRepositry
    {
        Task<List<Student>> GetAllStudent(CancellationToken cancellationToken);
        Task<Student> GetStudentById(Guid id, CancellationToken cancellationToken);
        Task<Student> AddStudent(Student newStudent, CancellationToken cancellationToken);
        Task<Student> UpdateStudent(Guid id, string FirstName,
                              string LastName, DateTime DateOfBirth,
                              string Address, string PhoneNumber,
                              string Email, CancellationToken cancellationToken);
        Task<Student> DeleteStudent(Guid id, CancellationToken cancellationToken);
    }
}
