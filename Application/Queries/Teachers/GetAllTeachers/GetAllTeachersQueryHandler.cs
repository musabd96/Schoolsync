using Domain.Models.Teacher;
using Infrastructure.Repositories.Teachers;
using MediatR;

namespace Application.Queries.Teachers.GetAllTeachers
{
    public class GetAllTeachersQueryHandler : IRequestHandler<GetAllTeachersQuery, List<Teacher>>
    {
        private readonly ITeacherRepository _teacherRepository;

        public GetAllTeachersQueryHandler(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<List<Teacher>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
        {
            List<Teacher> allTeachersFromDatabase = await _teacherRepository.GetAllTeachers(cancellationToken);
            if (allTeachersFromDatabase == null)
            {
                throw new InvalidOperationException("No Teacher was Found");

            }

            return allTeachersFromDatabase;


        }


    }
}
