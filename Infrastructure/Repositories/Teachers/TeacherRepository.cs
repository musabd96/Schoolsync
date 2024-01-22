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

        public Task<List<Teacher>> GetAllTeacher(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Teacher> GetTeacherById(Guid id, CancellationToken cancellationToken)
        {
            Teacher teacher = _appDbContext.Teacher.FirstOrDefault(t => t.Id == id)!;

            return Task.FromResult(teacher);
        }

        public Task<Teacher> AddTeacher(Teacher newTeacher, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();

        }

        public Task<Teacher> UpdateTeacher(Guid id, string FirstName, string LastName, string Address, string PhoneNumber, string Email, CancellationToken cancellationToken)
        {
            try
            {
                Teacher teacherToUpdate = _appDbContext.Teacher.FirstOrDefault(x => x.Id == id)!;

                _appDbContext.Update(teacherToUpdate);
                _appDbContext.SaveChanges();
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
                var teacherToDelete = _appDbContext.Teacher.FirstOrDefault(t => t.Id == id);

                _appDbContext.Remove(teacherToDelete!);
                _appDbContext.SaveChangesAsync().Wait();
                return Task.FromResult(teacherToDelete!);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting a teacher with ID{id} from the database", ex);
            }
        }

    }
}
