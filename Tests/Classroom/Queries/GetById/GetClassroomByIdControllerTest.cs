using Application.Queries.Classrooms.GetClassroomsById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ReactApp.Server.Controllers.ClassroomController;

namespace Tests.Classroom.Queries.GetById
{
    [TestFixture]
    public class GetClassroomByIdControllerTest
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
        public async Task GetClassroomById_ReturnsOkObjectResult_WhenClassroomExists()
        {
            // Arrange
            var classroomId = new Guid();
            var expectedClassroom = new Domain.Models.Classrooms.Classroom();

            Mock.Get(_mediator)
                .Setup(mediator => mediator.Send(It.IsAny<GetClassroomByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedClassroom);

            // Act
            var result = await _controller.GetClassroomById(classroomId);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.InstanceOf<OkObjectResult>());
                Assert.That((result as OkObjectResult)?.StatusCode, Is.EqualTo(200));
            });
        }

        [Test]
        public async Task GetClassroomById_ShouldReturnInternalServerErrorOnException()
        {
            // Arrange
            var classroomId = new Guid();

            Mock.Get(_mediator)
                .Setup(mediator => mediator.Send(It.IsAny<GetClassroomByIdQuery>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Simulated exception"));

            // Act
            var result = await _controller.GetClassroomById(classroomId);

            // Assert
            Assert.That(result, Is.InstanceOf<ObjectResult>());
            var objectResult = (ObjectResult)result;
            Assert.That(objectResult.StatusCode, Is.EqualTo(500));
        }
    }
}
