using Domain.Models.Student;
using Infrastructure.Repositories.Students;
using MediatR;

namespace Application.Commands.Students.UpdateStudent
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, Student>
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            // Update the student details
            var Id = request.Id;
            var FirstName = request.UpdateStudent.FirstName;
            var LastName = request.UpdateStudent.LastName;
            var DateOfBirth = request.UpdateStudent.DateOfBirth;
            var Address = request.UpdateStudent.Address;
            var PhoneNumber = request.UpdateStudent.PhoneNumber;
            var Email = request.UpdateStudent.Email;

            var studentToUpdate = await _studentRepository.UpdateStudent(Id, FirstName, LastName, DateOfBirth, Address, PhoneNumber, Email, cancellationToken);

            return studentToUpdate!;
        }
    }
}
