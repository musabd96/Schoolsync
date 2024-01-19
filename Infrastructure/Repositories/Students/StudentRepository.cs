﻿
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

        public Task<Student> DeleteStudent(Guid id, CancellationToken cancellationToken)
        {
            Student student = _appDbContext.Student.FirstOrDefault(s => s.Id == id)!;

            return Task.FromResult(student);
        }

        public async Task<List<Student>> GetAllStudentsAsync(CancellationToken cancellationToken)
        {
            return await _appDbContext.Student.ToListAsync();
        }

        public async Task<Student> GetStudentById(Guid id, CancellationToken cancellationToken)
        {
            return await _appDbContext.Student.FindAsync(id);
        }

        public Task<Student> UpdateStudent(Guid id, string FirstName, string LastName, DateTime DateOfBirth, string Address, string PhoneNumber, string Email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
