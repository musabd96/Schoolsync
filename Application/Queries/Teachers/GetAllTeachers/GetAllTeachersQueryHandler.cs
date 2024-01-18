
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Dtos;
using MediatR;

namespace Application.Queries.Teachers.GetAllTeachers
{
    public class GetAllTeachersQueryHandler : IRequestHandler<GetAllTeachersQuery, List<TeacherDto>>
    {
        
        private static readonly List<TeacherDto> SampleTeachers = new List<TeacherDto>
        {
            new TeacherDto
            {
                FirstName = "Hüseyin",
                LastName = "Sürer",
                DateOfBirth = new System.DateTime(1998, 5, 12),
                Adress = "Byalagsgatan5 123, Göteborg",
                PhoneNumber = "+46 79 567 32 77",
                Email = "husko.håkansson@schoolsync.com"
            },
            new TeacherDto
            {
                FirstName = "Niklas",
                LastName = "Cesar",
                DateOfBirth = new System.DateTime(1989, 5, 5),
                Adress = "Rymdtorget 1, Mölndal",
                PhoneNumber = "+46 76 789 01 23",
                Email = "cesar.biggy@schoolsync.com"
            }
        };

        public async Task<List<TeacherDto>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
        {
            
            return await Task.FromResult(SampleTeachers);
        }
    }
}
