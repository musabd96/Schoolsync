using Application.Queries.Students.GetStudentById;
using Infrastructure.Repositories.Students;
using Moq;
using NUnit.Framework;

namespace Tests.Student.Queries.GetStudentById
{
    [TestFixture]
    public class GetStudentByIdTests
    {
        private GetStudentByIdQueryHandler? _handler;
        private Mock<IStudentRepository>? _studentRepositoryMock;

        public void Setup()
        {
            _studentRepositoryMock = new Mock<IStudentRepository>();
            _handler = new GetStudentByIdQueryHandler(_studentRepositoryMock.Object);

            _studentRepositoryMock.Setup(repo => repo.GetStudentById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Domain.Models.Student.Student
                {
                    Id = new Guid("376ba7ab-47ee-4260-90c6-49c469e078f0"),
                    FirstName = "Nour",
                    LastName = "Solaiman",
                    DateOfBirth = new DateOnly(1984, 1, 15),
                    Address = "123 Main St, Cityville",
                    PhoneNumber = "+1 444-0123",
                    Email = "nour.solaiman@example.com"
                });
        }
        [Test]
        public async Task Handle_ValidId_ReturnsCorrectStudent()
        {
            // Arrange
            Setup();
            var studentId = new Guid("376ba7ab-47ee-4260-90c6-49c469e078f0");

            var query = new GetStudentByIdQuery(studentId);

            // Act
            var result = await _handler!.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result, "The result should not be null");
            Assert.That(result.Id, Is.EqualTo(studentId));
        }

        [Test]
        public async Task Handle_InvalidId_ReturnsNull()
        {
            // Arrange
            Setup();
            var invalidStudentId = Guid.NewGuid();

            _studentRepositoryMock!.Setup(repo => repo.GetStudentById(invalidStudentId, It.IsAny<CancellationToken>()))
                .ReturnsAsync((Domain.Models.Student.Student)null!);

            var query = new GetStudentByIdQuery(invalidStudentId);

            // Act
            var result = await _handler!.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }
}