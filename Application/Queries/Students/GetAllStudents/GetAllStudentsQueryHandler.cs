using Domain.Models.Student;
using Infrastructure.Repositories.Students;
using MediatR;

namespace Application.Queries.Students.GetAllStudents
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, List<Student>>
    {
        private readonly IStudentRepository _studentRepository;

        public GetAllStudentsQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<Student>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            List<Student> allStudentsFromDatabase = await _studentRepository.GetAllStudentsAsync(cancellationToken);
            if (allStudentsFromDatabase == null)
            {
                throw new InvalidOperationException("No Student was Found");

            }

            return allStudentsFromDatabase;


        }


    }
}
