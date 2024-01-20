using Application.Commands.Students.AddStudent;
using Application.Dtos;
using Infrastructure.Repositories.Students;
using Moq;
using NUnit.Framework;

namespace Tests.Student.Commands.AddStudent
{
    [TestFixture]
    public class AddStudentTests
    {
        private AddStudentCommandHandler _handler;
        private Mock<IStudentRepository> _studentRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _studentRepositoryMock = new Mock<IStudentRepository>();
            _handler = new AddStudentCommandHandler(_studentRepositoryMock.Object);
        }

        protected void SetupMockDbContext(List<Domain.Models.Student.Student> students)
        {
            _studentRepositoryMock.Setup(repo => repo.AddStudent(It.IsAny<Domain.Models.Student.Student>(), It.IsAny<CancellationToken>()))
                .Callback((Domain.Models.Student.Student student,
                    CancellationToken cancellationToken) => students.Add(student))
                .Returns((Domain.Models.Student.Student student,
                    CancellationToken cancellationToken) => Task.FromResult(student));
        }

        [Test]
        public async Task Handle_ValidStudent_ReturnsNewStudent()
        {
            // Arrange
            var newStudent = new StudentDto
            {
                FirstName = "John"
            };

            var addStudentCommand = new AddStudentCommand(newStudent);

            // Act
            var result = await _handler!.Handle(addStudentCommand, CancellationToken.None);

            // Assert
            Assert.That(result.FirstName, Is.EqualTo(newStudent.FirstName));
        }
    }
}
