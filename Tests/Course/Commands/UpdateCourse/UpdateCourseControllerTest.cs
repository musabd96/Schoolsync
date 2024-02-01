using Application.Commands.Courses.UpdateCourse;
using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ReactApp.Server.Controllers.CourseController;

namespace Tests.Course.Commands.UpdateCourse
{
    [TestFixture]
    public class UpdateCourseControllerTest
    {
        private IMediator _mediator;
        private CourseController _controller;

        [SetUp]
        public void Setup()
        {
            _mediator = Mock.Of<IMediator>();
            _controller = new CourseController(_mediator);
        }

        [Test]
        public async Task UpdateCourse_ShouldReturnOk()
        {
            // Arrange 
            var courseId = new Guid("12345678-1234-5678-1234-567812345678");
            var updatedCourse = new CourseDto
            {
                CourseName = "Svenska 1",
            };
            var command = new UpdateCourseCommand(updatedCourse, courseId);

            Mock.Get(_mediator)
                .Setup(x => x.Send(It.IsAny<UpdateCourseCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Domain.Models.Course.Course());

            // Act
            var result = await _controller.UpdateCourse(updatedCourse, courseId);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.InstanceOf<OkObjectResult>());
                Assert.That((result as OkObjectResult)?.StatusCode, Is.EqualTo(200));
            });
        }

        [Test]
        public async Task UpdateCourse_ShouldReturnInternalServerErrorOnException()
        {
            // Arrange 
            var courseId = new Guid("12345678-1234-5678-1234-567812345678");
            var updatedCourse = new CourseDto
            {
                CourseName = "Svenska 2",
            };
            var command = new UpdateCourseCommand(updatedCourse, courseId);

            // Arrange
            Mock.Get(_mediator)
                .Setup(x => x.Send(It.IsAny<UpdateCourseCommand>(), default))
                .Throws(new Exception("Simulated error"));

            // Act
            var result = await _controller.UpdateCourse(updatedCourse, courseId);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.InstanceOf<ObjectResult>());
                Assert.That((result as ObjectResult)?.StatusCode, Is.EqualTo(500));
            });
        }
    }
}
