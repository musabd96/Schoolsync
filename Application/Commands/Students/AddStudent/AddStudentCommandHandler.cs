using Domain.Models.Student;
using MediatR;
using Infrastructure.Repositories.Students;

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
                Id = Guid.NewGuid(),
                FirstName = request.Student.FirstName,
                LastName = request.Student.LastName,
                DateOfBirth = request.Student.DateOfBirth,
                Address = request.Student.Address,
                PhoneNumber = request.Student.PhoneNumber,
                Email = request.Student.Email
            };

            await _studentRepository.AddStudent(newStudent, cancellationToken);

            return (newStudent);
        }
    }
}
