using Domain.Models.Student;

namespace Infrastructure.Repositories.Students
{
    public interface IStudentRepository
    {
        Task<List<StudentModel>> GetAllStudentsAsync(CancellationToken cancellationToken);

        Task<StudentModel> GetStudentById(Guid id, CancellationToken cancellationToken);
        Task<StudentModel> AddStudent(StudentModel newStudent, CancellationToken cancellationToken);
        Task<StudentModel> UpdateStudent(Guid id, string FirstName,
                              string LastName, DateTime DateOfBirth,
                              string Address, string PhoneNumber,
                              string Email, CancellationToken cancellationToken);
        Task<StudentModel> DeleteStudent(Guid id, CancellationToken cancellationToken);
    }
}
