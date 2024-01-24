using Application.Commands.Teachers.AddTeacher;
using Application.Dtos;
using Infrastructure.Repositories.Teachers;
using Moq;
using NUnit.Framework;

namespace Tests.Teacher.Commands.AddTeacher
{
    [TestFixture]
    public class AddTeacherTests
    {
        private AddTeacherCommandHandler _handler;
        private Mock<ITeacherRepository> _teacherRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _teacherRepositoryMock = new Mock<ITeacherRepository>();
            _handler = new AddTeacherCommandHandler(_teacherRepositoryMock.Object);
        }

        protected void SetupMockDbContext(List<Domain.Models.Teacher.Teacher> teachers)
        {
            _teacherRepositoryMock.Setup(repo => repo.AddTeacher(It.IsAny<Domain.Models.Teacher.Teacher>(), It.IsAny<CancellationToken>()))
                .Callback((Domain.Models.Teacher.Teacher teacher,
                    CancellationToken cancellationToken) => teachers.Add(teacher))
                .Returns((Domain.Models.Teacher.Teacher teacher,
                    CancellationToken cancellationToken) => Task.FromResult(teacher));
        }

        [Test]
        public async Task Handle_ValidTeacher_ReturnsNewTeacher()
        {
            // Arrange
            var newTeacher = new TeacherDto
            {
                FirstName = "John"
            };

            var addTeacherCommand = new AddTeacherCommand(newTeacher);

            // Act
            var result = await _handler!.Handle(addTeacherCommand, CancellationToken.None);

            // Assert
            Assert.That(result.FirstName, Is.EqualTo(newTeacher.FirstName));
        }
    }
}
