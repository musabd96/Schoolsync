using Application.Commands.Course.DeleteCourse;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ReactApp.Server.Controllers.CourseController;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tests.Course.Commands.DeleteCourse
{
    [TestFixture]
    public class DeleteCourseControllerTest
    {
        private IMediator _mediator;
        private CourseController _controller;

        [SetUp]
        public void Setup()
        {
            // Initialize or mock IMediator implementation (dependency injection)
            _mediator = Mock.Of<IMediator>();

            _controller = new CourseController(_mediator);
        }

        [Test]
        public async Task DeleteCourse_ShouldReturnOk()
        {
            // Arrange 
            var courseId = new Guid("12345678-1234-5678-1234-567812345678");

            var command = new DeleteCourseCommand(courseId);

            // Mock the Send method of IMediator to return the expected result
            Mock.Get(_mediator)
                .Setup(x => x.Send(It.IsAny<DeleteCourseCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Domain.Models.Course.Course());

            // Act
            var result = await _controller.DeleteCoursemById(courseId);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            Assert.That((result as OkObjectResult)?.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public async Task DeleteCourse_ShouldReturnInternalServerErrorOnException()
        {
            // Arrange 
            var courseId = Guid.NewGuid();

            // Arrange
            Mock.Get(_mediator)
                .Setup(x => x.Send(It.IsAny<DeleteCourseCommand>(), default))
                .Throws(new Exception("Simulated error"));

            // Act
            var result = await _controller.DeleteCourseById(courseId);

            // Assert
            Assert.That(result, Is.InstanceOf<ObjectResult>());
            Assert.That((result as ObjectResult)?.StatusCode, Is.EqualTo(500));
        }
    }
}

