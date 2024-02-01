using Application.Queries.Teachers.GetTeacherById;
using Application.Validators.GuidValidation;
using Application.Validators.Teachers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ReactApp.Server.Controllers.TeacherController;

namespace Tests.Teacher.Queries.GetTeacherById
{
    [TestFixture]
    public class GetTeacherByIdControllerTests
    {
        private IMediator _mediator;
        private TeacherController _controller;

        public void Setup()
        {
            // Initialize or mock IMediator implementation (dependency injection)
            _mediator = Mock.Of<IMediator>();

            // Mock the TeacherValidator and GuidValidator
            var teacherValidator = Mock.Of<TeacherValidator>();
            var guidValidator = Mock.Of<GuidValidator>();

            _controller = new TeacherController(_mediator, teacherValidator, guidValidator);
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
