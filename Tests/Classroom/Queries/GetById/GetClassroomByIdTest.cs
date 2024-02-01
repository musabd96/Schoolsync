using Application.Queries.Classrooms.GetClassroomsById;
using Infrastructure.Repositories.Classrooms;
using Moq;
using NUnit.Framework;

namespace Tests.Classroom.Queries.GetById
{
    [TestFixture]
    public class GetClassroomByIdTest
    {
        private GetClassroomByIdQueryHandler? _handler;
        private Mock<IClassroomRepository>? _classroomRepositoryMock;

        public void Setup()
        {
            _classroomRepositoryMock = new Mock<IClassroomRepository>();
            _handler = new GetClassroomByIdQueryHandler(_classroomRepositoryMock.Object);

            _classroomRepositoryMock.Setup(repo => repo.GetClassroomById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Domain.Models.Classrooms.Classroom
                {
                    Id = new Guid("376ba7ab-47ee-4260-90c6-49c469e078f0"),
                    ClassroomName = "Atlas"
                });
        }
        [Test]
        public async Task Handle_ValidId_ReturnsCorrectClassroom()
        {
            // Arrange
            Setup();
            var classroomId = new Guid("376ba7ab-47ee-4260-90c6-49c469e078f0");

            var query = new GetClassroomByIdQuery(classroomId);

            // Act
            var result = await _handler!.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null, "The result should not be null");
            Assert.That(result.Id, Is.EqualTo(classroomId));
        }

        [Test]
        public async Task Handle_InvalidId_ReturnsNull()
        {
            // Arrange
            Setup();
            var invalidClassroomId = Guid.NewGuid();

            _classroomRepositoryMock!.Setup(repo => repo.GetClassroomById(invalidClassroomId, It.IsAny<CancellationToken>()))
                .ReturnsAsync((Domain.Models.Classrooms.Classroom)null!);

            var query = new GetClassroomByIdQuery(invalidClassroomId);

            // Act
            var result = await _handler!.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Null);
        }
    }
}
