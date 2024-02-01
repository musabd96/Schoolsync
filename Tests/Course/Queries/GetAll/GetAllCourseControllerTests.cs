

using Application.Queries.Courses.GetAllCourses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ReactApp.Server.Controllers.CourseController;

namespace Tests.Course.Queries.GetAll
{
    [TestFixture]
    public class GetAllCourseControllerTests
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
        public async Task GetAllCourses_ShouldReturnOk()
        {
            // Arrange
            var expectedCourses = new List<Domain.Models.Course.Course>
        {
            new Domain.Models.Course.Course
            {
                CourseName = "Test",
            },
            new Domain.Models.Course.Course           {
                CourseName = "Test2"
            }
        };

            var query = new GetAllCourseQuery();

            // Mock the Send method of IMediator to return the expected result
            // Mock the Send method of IMediator to return the expected result
            Mock.Get(_mediator)
                .Setup(x => x.Send(It.IsAny<GetAllCourseQuery>(), default(CancellationToken)))
                .ReturnsAsync(expectedCourses);


            // Act
            var result = await _controller.GetAllCourses();

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            Assert.That((result as OkObjectResult)?.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public async Task GetAllCourses_ShouldReturnInternalServerErrorOnException()
        {
            // Arrange
            Mock.Get(_mediator)
                .Setup(x => x.Send(It.IsAny<GetAllCourseQuery>(), default))
                .Throws(new Exception("Simulated error"));

            // Act
            var result = await _controller.GetAllCourses();

            // Assert
            Assert.That(result, Is.InstanceOf<ObjectResult>());
            Assert.That((result as ObjectResult)?.StatusCode, Is.EqualTo(500));
        }
    }
}
