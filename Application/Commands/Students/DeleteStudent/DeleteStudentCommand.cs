using Domain.Models.Student;
using MediatR;

namespace Application.Commands.Students.DeleteStudent
{
    public class DeleteStudentCommand : IRequest<Student> 
    {
        public DeleteStudentCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
