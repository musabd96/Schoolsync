using System.Threading.Tasks;
using Application.Commands.Classrooms.AddClassroom;
using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ReactApp.Server.Controllers.ClassroomController;

namespace Tests.Classroom.Controllers
{
    [TestFixture]
    public class AddClassroomControllerTests
    {
        private ClassroomController _controller;
        private IMediator _mediator;

        [SetUp]
        public void Setup()
        {
            // Initialize or mock IMediator implementation (dependency injection)
            _mediator = Mock.Of<IMediator>();

            _controller = new ClassroomController(_mediator);
        }

        [Test]
        public async Task AddClassroom_ValidInput_ReturnsOkResult()
        {
            // Arrange
            var newClassroom = new ClassroomDto
            {
                ClassroomName = "Math101"
            };

            // Mock the Send method of IMediator to return the expected result
            Mock.Get(_mediator)
                .Setup(x => x.Send(It.IsAny<AddClassroomCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Domain.Models.Classrooms.Classroom());

            // Act
            var result = await _controller.AddClassroom(newClassroom);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            Assert.That((result as OkObjectResult)?.StatusCode, Is.EqualTo(200));
        }
    }
}
