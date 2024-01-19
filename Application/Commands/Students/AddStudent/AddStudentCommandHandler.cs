
using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Models.Student;
using MediatR;

namespace Application.Commands.Students.AddStudent
{
    public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, Student>
    {
        private readonly IStudentRepository _studentRepository;

        public AddStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            // Skapa en ny student
            var newStudent = new Student
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                DateOfBirth = request.DateOfBirth,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email
            };

            // Lägg till studenten i kontexten och spara ändringarna i databasen
            _context.Students.Add(newStudent);
            await _context.SaveChangesAsync(cancellationToken);

            // Returnera studentens ID efter att den har lagts till
            return newStudent.Id;
        }
    }
}
