using Domain.Models.Teacher;
using Infrastructure.Repositories.Teachers;
using MediatR;

namespace Application.Commands.Teachers.UpdateTeacher
{
    public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, Teacher>
    {
        private readonly ITeacherRepository _teacherRepository;

        public UpdateTeacherCommandHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public async Task<Teacher> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            var Id = request.Id;
            var FirstName = request.UpdatedTeacher.FirstName;
            var LastName = request.UpdatedTeacher.LastName;
            var DateOfBirth = request.UpdatedTeacher.DateOfBirth;
            var Address = request.UpdatedTeacher.Address;
            var PhoneNumber = request.UpdatedTeacher.PhoneNumber;
            var Email = request.UpdatedTeacher.Email;

            var teacherToUpdate = await _teacherRepository.UpdateTeacher(Id, FirstName, LastName, DateOfBirth, Address, PhoneNumber, Email, cancellationToken);

            return teacherToUpdate!;
        }
    }
}
