using Application.Dtos;
using Domain.Models.Student;
using MediatR;

namespace Application.Commands.Students.UpdateStudent
{
    public class UpdateStudentCommand : IRequest<Student>
    {
        public UpdateStudentCommand(StudentDto updateStudent, Guid id)
        {
            UpdateStudent = updateStudent;
            Id = id;
        }
        public StudentDto UpdateStudent { get; set; }
        public Guid Id { get; set; }
    }
}
