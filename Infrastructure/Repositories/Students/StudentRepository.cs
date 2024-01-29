
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

        public async Task<Student> GetStudentById(Guid id, CancellationToken cancellationToken)
        {
            return await _appDbContext.Student.FindAsync(id);
        }

        public async Task<Student> UpdateStudent(Guid id, string FirstName, string LastName, DateOnly DateOfBirth, string Address, string PhoneNumber, string Email, CancellationToken cancellationToken)
        {
            Student studentToUpdate = await _appDbContext.Student.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
            if (studentToUpdate == null)
            {
                return null!;
            }
            // Update the student details
            studentToUpdate!.FirstName = FirstName;
            studentToUpdate.LastName = LastName;
            studentToUpdate.DateOfBirth = DateOfBirth;
            studentToUpdate.Adress = Address;
            studentToUpdate.PhoneNumber = PhoneNumber;
            studentToUpdate.Email = Email;

            _appDbContext.Update(studentToUpdate);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return studentToUpdate;
        }
    }
}
