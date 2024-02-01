
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
        public async Task<Student> AddStudent(Student newStudent, CancellationToken cancellationToken)
        {
            // Lägg till den nya studenten i DbSet och spara ändringarna i databasen
            _appDbContext.Student.Add(newStudent);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return newStudent;
        }

        public async Task DeleteStudent(Guid id, CancellationToken cancellationToken)
        {
            var studentToDelete = await _appDbContext.Student.FindAsync(id);
            if (studentToDelete != null)
            {
                _appDbContext.Student.Remove(studentToDelete);
                await _appDbContext.SaveChangesAsync();

            }
        }

        public async Task<List<Student>> GetAllStudentsAsync(CancellationToken cancellationToken)
        {
            return await _appDbContext.Student.ToListAsync();
        }

        public Task<Student> GetStudentById(Guid id, CancellationToken cancellationToken)
        {
            Student student = _appDbContext.Student.FirstOrDefault(t => t.Id == id)!;

            return Task.FromResult(student);
        }

        public Task<Student> UpdateStudent(Guid id, string FirstName, string LastName, DateOnly DateOfBirth, string Address, string PhoneNumber, string Email, CancellationToken cancellationToken)
        {
            try
            {
                Student studentToUpdate = _appDbContext.Student.FirstOrDefault(s => s.Id == id)!;

                if (studentToUpdate != null)
                {
                    // Update the student details
                    studentToUpdate.FirstName = FirstName;
                    studentToUpdate.LastName = LastName;
                    studentToUpdate.DateOfBirth = DateOfBirth;
                    studentToUpdate.Address = Address;
                    studentToUpdate.PhoneNumber = PhoneNumber;
                    studentToUpdate.Email = Email;

                    _appDbContext.Update(studentToUpdate);  // No issues with nullability here
                    _appDbContext.SaveChangesAsync(cancellationToken);
                }

                return Task.FromResult(studentToUpdate)!;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating a student with ID {id} in the database", ex);
            }
        }
    }
}
