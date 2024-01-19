using Application.Queries.Teachers.GetTeacherById;
using Infrastructure.Repositories.Teachers;
using Moq;
using NUnit.Framework;

namespace Tests.Teacher.Queries.GetTeacherById
{
    [TestFixture]
    public class GetTeacherByIdTests
    {
        private GetTeacherByIdQueryHandler? _handler;
        private Mock<ITeacherRepository>? _teacherRepositoryMock;

        public void Setup()
        {
            _teacherRepositoryMock = new Mock<ITeacherRepository>();
            _handler = new GetTeacherByIdQueryHandler(_teacherRepositoryMock.Object);

            _teacherRepositoryMock.Setup(repo => repo.GetTeacherById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Domain.Models.Teacher.Teacher
                {
                    Id = new Guid("376ba7ab-47ee-4260-90c6-49c469e078f0"),
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = new DateOnly(1982, 1, 15),
                    Adress = "123 Main St, Cityville",
                    PhoneNumber = "+1 555-1234",
                    Email = "john.doe@example.com"
                });
        }
        [Test]
        public async Task Handle_ValidId_ReturnsCorrectTeacher()
        {
            // Arrange
            Setup();
            var teacherId = new Guid("376ba7ab-47ee-4260-90c6-49c469e078f0");

            var query = new GetTeacherByIdQuery(teacherId);

            // Act
            var result = await _handler!.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result, "The result should not be null");
            Assert.That(result.Id, Is.EqualTo(teacherId));
        }

        [Test]
        public async Task Handle_InvalidId_ReturnsNull()
        {
            // Arrange
            Setup();
            var invalidTeacherId = Guid.NewGuid();

            _teacherRepositoryMock!.Setup(repo => repo.GetTeacherById(invalidTeacherId, It.IsAny<CancellationToken>()))
                .ReturnsAsync((Domain.Models.Teacher.Teacher)null!);

            var query = new GetTeacherByIdQuery(invalidTeacherId);

            // Act
            var result = await _handler!.Handle(query, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }
}
