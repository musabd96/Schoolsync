using Application.Commands.Teachers.DeleteTeacher;
using Application.Validators.GuidValidation;
using Application.Validators.Teachers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ReactApp.Server.Controllers.TeacherController;

namespace Tests.Teacher.Commands.DeleteTeacher
{
    [TestFixture]
    public class DeleteTeacherControllerTest
    {
        private IMediator _mediator;
        private TeacherController _controller;

        [SetUp]
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
        public async Task DeleteTeacher_ShouldReturnOk()
        {
            // Arrange 
            var teacherId = new Guid("12345678-1234-5678-1234-567812345678");

            var command = new DeleteTeacherCommand(teacherId);

            // Mock the Send method of IMediator to return the expected result
            Mock.Get(_mediator)
                .Setup(x => x.Send(It.IsAny<DeleteTeacherCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Domain.Models.Teacher.Teacher());

            // Act
            var result = await _controller.DeleteTeacherById(teacherId);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            Assert.That((result as OkObjectResult)?.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public async Task DeleteTeacher_ShouldReturnInternalServerErrorOnException()
        {
            // Arrange 
            var teacherId = Guid.NewGuid();
            // Arrange
            Mock.Get(_mediator)
                .Setup(x => x.Send(It.IsAny<DeleteTeacherCommand>(), default))
                .Throws(new Exception("Simulated error"));

            // Act
            var result = await _controller.DeleteTeacherById(teacherId);

            // Assert
            Assert.That(result, Is.InstanceOf<ObjectResult>());
            Assert.That((result as ObjectResult)?.StatusCode, Is.EqualTo(500));
        }
    }
}
