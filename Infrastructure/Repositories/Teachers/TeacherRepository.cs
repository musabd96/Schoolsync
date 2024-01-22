

using Domain.Models.Student;
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
            Teacher teacher = _appDbContext.Teacher.FirstOrDefault(t => t.Id == id)!;

            return Task.FromResult(teacher);
        }
        public async Task<Teacher> AddTeacher(Teacher newTeacher, CancellationToken cancellationToken)
        {
            // Lägg till den nya läraren i DbSet och spara ändringarna i databasen
            _appDbContext.Teacher.Add(newTeacher);
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return newTeacher;
        }

        public Task<Teacher> UpdateTeacher(Guid id, string FirstName, string LastName, DateTime DateOfBirth, string Address, string PhoneNumber, string Email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Teacher> DeleteTeacher(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var teacherToDelete = _appDbContext.Teacher.FirstOrDefault(t => t.Id == id);

                _appDbContext.Remove(teacherToDelete!);
                _appDbContext.SaveChangesAsync().Wait();
                return Task.FromResult(teacherToDelete!);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting a teacher with ID{id} from the database");
            }
        }

    }
}
