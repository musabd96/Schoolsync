using Application.Commands.Classrooms.DeleteClassroom;
using Domain.Models.Classrooms;
using Infrastructure.Repositories.Classrooms;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Tests.Classroom.Commands.DeleteClassroom
{
    [TestFixture]
    public class DeleteClassroomTest
    {
        private DeleteClassroomCommandHandler _handler;
        private Mock<IClassroomRepository> _classroomRepository;

        [SetUp]
        public void SetUp()
        {
            _classroomRepository = new Mock<IClassroomRepository>();
            _handler = new DeleteClassroomCommandHandler(_classroomRepository.Object);
        }

        protected void SetupMockDbContext(List<Domain.Models.Classrooms.Classroom> classrooms)
        {
            _classroomRepository.Setup(repo => repo.DeleteClassroom(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .Returns((Guid classroomId, CancellationToken cancellationToken) =>
                {
                    var classroomToDelete = classrooms.FirstOrDefault(c => c.Id == classroomId);

                    return Task.FromResult<Domain.Models.Classrooms.Classroom>(null!);
                });
        }

        [Test]
        public async Task DeleteClassroomById_ReturnsOkObjectResult_WhenClassroomExists()
        {
            // Arrange
            var classroomId = new Guid("12345678-1234-5678-1234-567812345678");
            var classrooms = new List<Domain.Models.Classrooms.Classroom>
            {
                new Domain.Models.Classrooms.Classroom
                {
                    Id = classroomId
                }
            };
            SetupMockDbContext(classrooms);

            var command = new DeleteClassroomCommand(classroomId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Null(result);
        }

        [Test]
        public async Task Handle_InvalidId_DoesNothing()
        {
            // Arrange
            var invalidClassroomId = Guid.NewGuid();
            var classrooms = new List<Domain.Models.Classrooms.Classroom>();
            SetupMockDbContext(classrooms);

            var command = new DeleteClassroomCommand(invalidClassroomId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }
}
