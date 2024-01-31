using Application.Commands.Classrooms.UpdateClassroom;
using Application.Commands.Classrooms.UpdateClassroom;
using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ReactApp.Server.Controllers.ClassroomController;

namespace Tests.Classroom.Commands.UpdateClassroom
{
    [TestFixture]
    public class UpdateClassroomControllerTests
    {
        private IMediator _mediator;
        private ClassroomController _controller;

        [SetUp]
        public void Setup()
        {
            _mediator = Mock.Of<IMediator>();
            _controller = new ClassroomController(_mediator);
        }

        [Test]
        public async Task UpdateClassroom_ReturnsOkObjectResult_WhenUpdateSuccessful()
        {
            // Arrange
            var updateClassroomId = Guid.NewGuid();
            var updatedClassroomDto = new ClassroomDto
            {
                ClassroomName = "Test",
            };

            var command = new UpdateClassroomCommand(updatedClassroomDto, updateClassroomId);
            Mock.Get(_mediator)
                .Setup(mediator => mediator.Send(It.IsAny<UpdateClassroomCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Domain.Models.Classrooms.Classroom());

            // Act
            var result = await _controller.UpdateClassroom(updatedClassroomDto, updateClassroomId);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            Assert.That((result as OkObjectResult)?.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public async Task UpdateClassroom_ShouldReturnInternalServerErrorOnException()
        {
            // Arrange
            var updateClassroomId = Guid.NewGuid();
            var updatedClassroomDto = new ClassroomDto { ClassroomName = "Test1" }; // Provide valid DTO for testing

            Mock.Get(_mediator)
                .Setup(mediator => mediator.Send(It.IsAny<UpdateClassroomCommand>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Simulated exception"));

            // Act
            var result = await _controller.UpdateClassroom(updatedClassroomDto, updateClassroomId);

            // Assert
            Assert.That(result, Is.InstanceOf<ObjectResult>());
            var objectResult = (ObjectResult)result;
            Assert.That(objectResult.StatusCode, Is.EqualTo(500));
        }
    }
}
