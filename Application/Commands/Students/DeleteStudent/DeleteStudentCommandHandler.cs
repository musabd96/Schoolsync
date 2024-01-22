using Domain.Models.Student;
using Infrastructure.Repositories.Students;
using MediatR;

namespace Application.Commands.Students.DeleteStudent
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, Student>
    {
        private readonly IStudentRepository _studentRepository;


        public DeleteStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;    

        }

        public async Task<Student> Handle(DeleteStudentCommand request, CancellationToken cancellation)
        {
            try
            {
                Student studentToDelete = await _studentRepository.GetStudentById(request.Id,cancellation);
                if(studentToDelete == null)
                {
                    throw new InvalidOperationException("No student with the given id was found");
                }

                await _studentRepository.DeleteStudent(request.Id,cancellation);

                return studentToDelete;

            }
            catch(Exception ex)
            {
                throw new InvalidOperationException("Error occurred while deleting the student.", ex);
            }
        }
    }
}
