using Application.Commands.Students.UpdateStudent;
using Application.Dtos;
using Infrastructure.Repositories.Students;
using Moq;
using NUnit.Framework;

namespace Tests.Student.Commands.UpdateStudent
{
    [TestFixture]
    public class UpdateStudentCommandHandlerTests
    {
        private UpdateStudentCommandHandler _handler;
        private Mock<IStudentRepository> _mockRepository;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IStudentRepository>();
            _handler = new UpdateStudentCommandHandler(_mockRepository.Object);
        }
        protected void SetupMockDbContext(List<Domain.Models.Student.Student> students)
        {
            _mockRepository.Setup(repo => repo.UpdateStudent(
                It.IsAny<Guid>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<DateOnly>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()
            ))
            .ReturnsAsync(
                (Guid id, string firstName, string lastName, DateOnly dateOfBirth, string address, string phoneNumber, string email, CancellationToken cancellationToken) =>
                {
                    var studentToUpdate = students.FirstOrDefault(s => s.Id == id);
                    return studentToUpdate!;
                }
             );
        }

        [Test]
        public async Task Handle_ReturnsUpdatedStudent_WhenUpdateSuccessful()
        {
            // Arrange
            var studentId = new Guid("12345678-1234-5678-1234-567812345678");
            var students = new List<Domain.Models.Student.Student> { new() { Id = studentId } };
            SetupMockDbContext(students);

            var command = new UpdateStudentCommand(
                updateStudent: new StudentDto
                {
                    FirstName = "Test",
                    LastName = "Testsson"
                },
                id: studentId
                );

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(studentId));
        }

        [Test]
        public async Task Handle_ReturnsNull_WhenStudentNotFound()
        {
            // Arrange
            var invalidStudentId = Guid.NewGuid();
            var students = new List<Domain.Models.Student.Student>();
            SetupMockDbContext(students);

            var command = new UpdateStudentCommand(updateStudent: new StudentDto(), id: invalidStudentId);
            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Null);
        }
    }
}
