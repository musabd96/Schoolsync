using Domain.Models.Teacher;
using Infrastructure.Repositories.Students;
using Infrastructure.Repositories.Teachers;
using MediatR;

namespace Application.Queries.Teachers.GetTeacherById
{
    public class GetTeacherByIdQueryHandler : IRequestHandler<GetTeacherByIdQuery, Teacher>
    {
        private readonly ITeacherRepository _teacherRepository;

        public GetTeacherByIdQueryHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<Teacher> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
        {
            Teacher wantedTeacher = await _teacherRepository.GetTeacherById(request.Id, cancellationToken);

            try
            {
                if (wantedTeacher == null)
                {
                    return null!;
                }
                return wantedTeacher;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
