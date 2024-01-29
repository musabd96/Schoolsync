using Application.Queries.Classrooms.GetAllClassrooms;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ReactApp.Server.Controllers.ClassroomController;

namespace Tests.Classroom.Queries.GetAll
{
    internal class GetAllClassroomControllerTests
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
        public async Task GetAllClassrooms_ShouldReturnOk()
        {
            // Arrange
            var expectedClassrooms = new List<Domain.Models.Classrooms.Classroom>
            {
                new() {
                    ClassroomName = "Trumpeten"
                },
                new () {
                    ClassroomName = "Nexus Classroom"
                }
            };

            var query = new GetAllClassroomQuery();

            Mock.Get(_mediator)
                .Setup(x => x.Send(It.IsAny<GetAllClassroomQuery>(), default))
                .ReturnsAsync(expectedClassrooms);

            // Act
            var result = await _controller.GetAllClassrooms();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.InstanceOf<OkObjectResult>());
                Assert.That((result as OkObjectResult)?.StatusCode, Is.EqualTo(200));
            });
        }

        [Test]
        public async Task GetAllClassrooms_ShouldReturnInternalServerErrorOnException()
        {
            // Arrange
            Mock.Get(_mediator)
                .Setup(x => x.Send(It.IsAny<GetAllClassroomQuery>(), default))
                .Throws(new Exception("Simulated error"));

            // Act
            var result = await _controller.GetAllClassrooms();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.InstanceOf<ObjectResult>());
                Assert.That((result as ObjectResult)?.StatusCode, Is.EqualTo(500));
            });
        }
    }
}
