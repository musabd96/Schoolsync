using Application.Queries.Course.GetCourseById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ReactApp.Server.Controllers.CourseController;

namespace Tests.Course.Queries.GetById
{
    [TestFixture]
    public class GetCourseByIdControllerTest
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
        public async Task GetCourseById_ReturnsOkObjectResult_WhenCourseExists()
        {
            // Arrange
            var courseId = new Guid();
            var expectedCourse = new Domain.Models.Course.Course();

            Mock.Get(_mediator)
                .Setup(mediator => mediator.Send(It.IsAny<GetCourseByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedCourse);

            // Act
            var result = await _controller.GetCourseById(courseId);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.InstanceOf<OkObjectResult>());
                Assert.That((result as OkObjectResult)?.StatusCode, Is.EqualTo(200));
            });
        }

        [Test]
        public async Task GetCourseById_ShouldReturnInternalServerErrorOnException()
        {
            // Arrange
            var courseId = new Guid();

            Mock.Get(_mediator)
                .Setup(mediator => mediator.Send(It.IsAny<GetCourseByIdQuery>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Simulated exception"));

            // Act
            var result = await _controller.GetCourseById(courseId);

            // Assert
            Assert.That(result, Is.InstanceOf<ObjectResult>());
            var objectResult = (ObjectResult)result;
            Assert.That(objectResult.StatusCode, Is.EqualTo(500));
        }
    }
}
