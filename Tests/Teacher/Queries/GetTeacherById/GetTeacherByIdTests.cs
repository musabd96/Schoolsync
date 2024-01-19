using Application.Queries.Teachers.GetTeacherById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ReactApp.Server.Controllers.TeacherController;

namespace Tests.Teacher.Queries.GetTeacherById
{
    [TestFixture]
    public class GetTeacherByIdTests
    {
        private IMediator _mediator;
        private TeacherController _controller;

        [SetUp]
        public void Setup()
        {
            _mediator = Mock.Of<IMediator>();
            _controller = new TeacherController(_mediator);
        }

        [Test]
        public async Task GetTeacherById_ReturnsOkObjectResult_WhenTeacherExists()
        {
            // Arrange
            var teacherId = new Guid();
            var expectedTeacher = new Domain.Models.Teacher.Teacher();

            Mock.Get(_mediator)
                .Setup(mediator => mediator.Send(It.IsAny<GetTeacherByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedTeacher);

            // Act
            var result = await _controller.GetTeacherById(teacherId);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            Assert.That((result as OkObjectResult)?.StatusCode, Is.EqualTo(200));
        }
        [Test]
        public async Task GetTeacherById_ShouldReturnInternalServerErrorOnException()
        {
            // Arrange
            var teacherId = new Guid();

            Mock.Get(_mediator)
                .Setup(mediator => mediator.Send(It.IsAny<GetTeacherByIdQuery>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Simulated exception"));

            // Act
            var result = await _controller.GetTeacherById(teacherId);

            // Assert
            Assert.That(result, Is.InstanceOf<ObjectResult>());
            var objectResult = (ObjectResult)result;
            Assert.That(objectResult.StatusCode, Is.EqualTo(500));
        }

    }
}
