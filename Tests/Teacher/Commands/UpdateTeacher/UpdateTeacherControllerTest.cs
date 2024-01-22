using Application.Commands.Teachers.UpdateTeacher;
using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ReactApp.Server.Controllers.TeacherController;

namespace Tests.Teacher.Commands.UpdateTeacher
{
    [TestFixture]
    public class UpdateTeacherControllerTest
    {
        private IMediator _mediator;
        private TeacherController _controller;
        private TeacherDto? updatedTeacherDto;

        [SetUp]
        public void Setup()
        {
            _mediator = Mock.Of<IMediator>();
            _controller = new TeacherController(_mediator);
        }
        [Test]
        public async Task UpdateTeacher_ShouldReturnOk()
        {
            // Arrange 
            var teacherId = new Guid("12345678-1234-5678-1234-567812345678");
            var command = new UpdateTeacherCommand(updatedTeacherDto!, teacherId);

            Mock.Get(_mediator)
                .Setup(x => x.Send(It.IsAny<UpdateTeacherCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Domain.Models.Teacher.Teacher());

            // Act
            var result = await _controller.UpdateTeacher(teacherId, command);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            Assert.That((result as OkObjectResult)?.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public async Task UpdateTeacher_ShouldReturnInternalServerErrorOnException()
        {
            // Arrange 
            var teacherId = Guid.NewGuid();
            var command = new UpdateTeacherCommand(updatedTeacherDto!, teacherId);

            // Arrange
            Mock.Get(_mediator)
                .Setup(x => x.Send(It.IsAny<UpdateTeacherCommand>(), default))
                .Throws(new Exception("Simulated error"));

            // Act
            var result = await _controller.UpdateTeacher(teacherId, command);

            // Assert
            Assert.That(result, Is.InstanceOf<ObjectResult>());
            Assert.That((result as ObjectResult)?.StatusCode, Is.EqualTo(500));
        }
    }
}
