using Application.Queries.Students.GetAllStudents;
using Domain.Models.Student;
using Infrastructure.Repositories.Students;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Student.Queries.NewFolder
{
    [TestFixture]
    public class GetAllStudentTests
    {
        private Mock<IStudentRepository> _studentRepositoryMock;

        private GetAllStudentsQueryHandler _handler;

        [Test]
        public async Task GetAllStudents_WhenStudentExists_ReturnallStudents()
        {
            

        }





    }
}
