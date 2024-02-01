using Application.Commands.Classrooms.UpdateClassroom;
using Application.Dtos;
using Infrastructure.Repositories.Classrooms;
using Moq;
using NUnit.Framework;

namespace Tests.Classroom.Commands.UpdateClassroom
{
    [TestFixture]
    public class UpdateClassroomTests
    {
        private UpdateClassroomCommandHandler _handler;
        private Mock<IClassroomRepository> _mockRepository;

        [SetUp]
        public void Setup()
        {
            _mockRepository = new Mock<IClassroomRepository>();
            _handler = new UpdateClassroomCommandHandler(_mockRepository.Object);
        }

        protected void SetupMockDbContext(List<Domain.Models.Classrooms.Classroom> classrooms)
        {
            _mockRepository.Setup(repo => repo.UpdateClassroom(
                It.IsAny<Guid>(),
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()
            ))
            .ReturnsAsync(
                (Guid id, string classroom, CancellationToken cancellationToken) =>
                {
                    var classroomToUpdate = classrooms.FirstOrDefault(cr => cr.Id == id);
                    return classroomToUpdate!;
                }
             );
        }

        [Test]
        public async Task Handle_ReturnsUpdatedClassroom_WhenUpdateSuccessful()
        {
            // Arrange
            var classroomId = new Guid("12345678-1234-5678-1234-567812345678");
            var classroom = new List<Domain.Models.Classrooms.Classroom> { new() { Id = classroomId } };
            SetupMockDbContext(classroom);

            var command = new UpdateClassroomCommand(
                updatedClassroom: new ClassroomDto
                {
                    ClassroomName = "Test",
                },
                id: classroomId
                );

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(classroomId));
        }

        [Test]
        public async Task Handle_ReturnsNull_WhenClassroomNotFound()
        {
            // Arrange
            var invalidClassroomId = Guid.NewGuid();
            var classrooms = new List<Domain.Models.Classrooms.Classroom>();
            SetupMockDbContext(classrooms);

            var command = new UpdateClassroomCommand(updatedClassroom: new ClassroomDto(), id: invalidClassroomId);
            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Null);
        }

    }
}
