using Domain.Models.Student;
using Infrastructure.Repositories.Students;
using MediatR;

namespace Application.Queries.Students.GetAllStudents
{
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, List<StudentModel>>
    {
        private readonly IStudentRepository _studentRepository;

        public GetAllStudentsQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<List<StudentModel>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            List<StudentModel> allStudentsFromDatabase = await _studentRepository.GetAllStudentsAsync(cancellationToken);
            if (allStudentsFromDatabase == null)
            {
                throw new InvalidOperationException("No Student was Found");

            }

            return allStudentsFromDatabase;


        }


    }
}
