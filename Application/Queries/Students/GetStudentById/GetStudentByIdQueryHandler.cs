using Domain.Models.Student;
using Infrastructure.Repositories.Students;
using MediatR;

namespace Application.Queries.Students.GetStudentById
{
    public class GetStudentByIdQueryHandler
    {
        public class GetStudenByIdQueryHandler(IStudentRepository? studentRepository) : IRequestHandler<GetStudentByIdQuery, Student>
        {
            private readonly IStudentRepository? _studentRepository = studentRepository;

            public async Task<Student> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
            {
                Student wantedStudent = await _studentRepository.GetStudentById(request.Id);

                try
                {
                    if (wantedStudent == null)
                    {
                        return null!;
                    }
                    return wantedStudent;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
