using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Commands.Classrooms.AddClassroom;
using Application.Dtos;
using Infrastructure.Repositories.Classrooms;
using Moq;
using NUnit.Framework;

namespace Tests.Classroom.Commands.AddClassroom
{
    [TestFixture]
    public class AddClassroomTests
    {
        private AddClassroomCommandHandler _handler;
        private Mock<IClassroomRepository> _classroomRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _classroomRepositoryMock = new Mock<IClassroomRepository>();
            _handler = new AddClassroomCommandHandler(_classroomRepositoryMock.Object);
        }

        protected void SetupMockDbContext(List<Domain.Models.Classrooms.Classroom> classrooms)
        {
            _classroomRepositoryMock.Setup(repo => repo.AddClassroom(It.IsAny<Domain.Models.Classrooms.Classroom>(), It.IsAny<CancellationToken>()))
                .Callback((Domain.Models.Classrooms.Classroom classroom,
                    CancellationToken cancellationToken) => classrooms.Add(classroom))
                .Returns((Domain.Models.Classrooms.Classroom classroom,
                    CancellationToken cancellationToken) => Task.FromResult(classroom));
        }

        [Test]
        public async Task Handle_ValidClassroom_ReturnsNewClassroom()
        {
            // Arrange
            var newClassroom = new ClassroomDto
            {
                ClassroomName = "Math101"
            };

            var addClassroomCommand = new AddClassroomCommand(newClassroom);

            // Act
            var result = await _handler!.Handle(addClassroomCommand, CancellationToken.None);

            // Assert
            Assert.That(result.ClassroomName, Is.EqualTo(newClassroom.ClassroomName));
        }
    }
}
