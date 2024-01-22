using Application.Commands.Teachers.UpdateTeacher;
using Infrastructure.Repositories.Teachers;
using Moq;
using NUnit.Framework;

namespace Tests.Teacher.Commands.UpdateTeacher
{
    [TestFixture]
    public class UpdateTeacherTest
    {
        private UpdateTeacherCommandHandler _handler;
        private Mock<ITeacherRepository> _teacherRepository;

        [SetUp]
        public void SetUp()
        {
            _teacherRepository = new Mock<ITeacherRepository>();
            _handler = new UpdateTeacherCommandHandler(_teacherRepository.Object);
        }

        // [Test]
        public Task Handle_ValidId_UpdatedTeacher()
        {
            throw new NotImplementedException();
        }

        // [Test]
        public Task Handle_InvalidId_ReturnsNull()
        {
            throw new NotImplementedException();
        }
    }
}
