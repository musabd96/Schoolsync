using Domain.Models.Teacher;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Teachers
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext _appDbContext;
        public TeacherRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Teacher>> GetAllTeachers(CancellationToken cancellationToken)
        {
            return await _appDbContext.Teacher.ToListAsync(cancellationToken);
        }

        public Task<Teacher> GetTeacherById(Guid id, CancellationToken cancellationToken)
        {
            var teacher = _appDbContext.Teacher.FirstOrDefaultAsync(t => t.Id == id)!;

            return Task.FromResult(teacher);
        }

        public async Task<Teacher> AddTeacher(Teacher newTeacher, CancellationToken cancellationToken)
        {
            // Check if email is unique before adding a new teacher
            var existingTeacherWithEmail = await _appDbContext.Teacher.FirstOrDefaultAsync(t => t.Email == newTeacher.Email);

            if (existingTeacherWithEmail != null)
            {
                throw new Exception("Teacher with the same email already exists.");
            }
            // Lägg till den nya läraren i DbSet och spara ändringarna i databasen
            _appDbContext.Teacher.Add(newTeacher);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return newTeacher;
        }

        public Task<Teacher> UpdateTeacher(Guid id, string FirstName, string LastName, DateOnly DateOfBirth, string Address, string PhoneNumber, string Email, CancellationToken cancellationToken)
        {
            try
            {
                Teacher teacherToUpdate = _appDbContext.Teacher.FirstOrDefault(x => x.Id == id)!;

                if (teacherToUpdate != null)
                {
                    teacherToUpdate.FirstName = FirstName;
                    teacherToUpdate.LastName = LastName;
                    teacherToUpdate.DateOfBirth = DateOfBirth;
                    teacherToUpdate.Address = Address;
                    teacherToUpdate.PhoneNumber = PhoneNumber;
                    teacherToUpdate.Email = Email;
                }

                _appDbContext.Update(teacherToUpdate!);
                _appDbContext.SaveChangesAsync(cancellationToken);
                return Task.FromResult(teacherToUpdate)!;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating a teacher with ID {id} in the database", ex);
            }
        }

        public Task<Teacher> DeleteTeacher(Guid id, CancellationToken cancellationToken)
        {
            try
            {
				var teacherToDelete = await _appDbContext.Teacher.FirstOrDefaultAsync(t => t.Id == id);

                if (teacherToDelete == null)
                {
                    throw new Exception($"Teacher with ID {id} not found.");
                }
                _appDbContext.Remove(teacherToDelete!);
                _appDbContext.SaveChangesAsync(cancellationToken);
                return Task.FromResult(teacherToDelete!);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting a teacher with ID{id} from the database", ex);
            }
        }

    }
}
