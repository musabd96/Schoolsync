﻿using Domain.Models.Student;

namespace Infrastructure.Repositories.Students
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudentsAsync(CancellationToken cancellationToken);

        Task<Student> GetStudentById(Guid id, CancellationToken cancellationToken);
        Task<Student> AddStudent(Student newStudent, CancellationToken cancellationToken);
        Task<Student> UpdateStudent(Guid id, string FirstName,
                              string LastName, DateOnly DateOfBirth,
                              string Address, string PhoneNumber,
                              string Email, CancellationToken cancellationToken);
        Task DeleteStudent(Guid id, CancellationToken cancellationToken);
    }
}
