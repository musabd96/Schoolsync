using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Models.Teacher;
using Infrastructure.Repositories.Teachers;
using MediatR;

namespace Application.Commands.Teachers.AddTeacher
{
    public class AddTeacherCommandHandler : IRequestHandler<AddTeacherCommand, Teacher>
    {
        private readonly ITeacherRepository _teacherRepository;

        public AddTeacherCommandHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<Teacher> Handle(AddTeacherCommand request, CancellationToken cancellationToken)
        {
            // Skapa en ny lärare
            var newTeacher = new Teacher
            {
                Id = Guid.NewGuid(),
                FirstName = request.Teacher.FirstName,
                LastName = request.Teacher.LastName,
                DateOfBirth = request.Teacher.DateOfBirth,
                Address = request.Teacher.Address,
                PhoneNumber = request.Teacher.PhoneNumber,
                Email = request.Teacher.Email
            };

            await _teacherRepository.AddTeacher(newTeacher, cancellationToken);

            return newTeacher;
        }
    }
}
