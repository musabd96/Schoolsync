using Application.Commands.Classrooms.DeleteClassroom;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ReactApp.Server.Controllers.ClassroomController;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tests.Classroom.Commands.DeleteClassroom
{
    [TestFixture]
    public class DeleteClassroomControllerTest
    {
        private IMediator _mediator;
        private ClassroomController _controller;

        [SetUp]
        public void Setup()
        {
            // Initialize or mock IMediator implementation (dependency injection)
            _mediator = Mock.Of<IMediator>();

            _controller = new ClassroomController(_mediator);
        }

        [Test]
        public async Task DeleteClassroom_ShouldReturnOk()
        {
            // Arrange 
            var classroomId = new Guid("12345678-1234-5678-1234-567812345678");

            var command = new DeleteClassroomCommand(classroomId);

            // Mock the Send method of IMediator to return the expected result
            Mock.Get(_mediator)
                .Setup(x => x.Send(It.IsAny<DeleteClassroomCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Domain.Models.Classrooms.Classroom());

            // Act
            var result = await _controller.DeleteClassroomById(classroomId);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            Assert.That((result as OkObjectResult)?.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public async Task DeleteClassroom_ShouldReturnInternalServerErrorOnException()
        {
            // Arrange 
            var classroomId = Guid.NewGuid();

            // Arrange
            Mock.Get(_mediator)
                .Setup(x => x.Send(It.IsAny<DeleteClassroomCommand>(), default))
                .Throws(new Exception("Simulated error"));

            // Act
            var result = await _controller.DeleteClassroomById(classroomId);

            // Assert
            Assert.That(result, Is.InstanceOf<ObjectResult>());
            Assert.That((result as ObjectResult)?.StatusCode, Is.EqualTo(500));
        }
    }
}

