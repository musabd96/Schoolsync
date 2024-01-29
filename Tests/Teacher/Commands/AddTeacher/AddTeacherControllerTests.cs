using System;
using System.Threading.Tasks;
using Application.Commands.Teachers.AddTeacher;
using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ReactApp.Server.Controllers.TeacherController;

namespace Tests.Teacher.Controllers
{
    [TestFixture]
    public class AddTeacherControllerTests
    {
        private TeacherController _controller;
        private IMediator _mediator;

        [SetUp]
        public void Setup()
        {
            // Initialize or mock IMediator implementation (dependency injection)
            _mediator = Mock.Of<IMediator>();

            _controller = new TeacherController(_mediator);
        }

        [Test]
        public async Task AddTeacher_ValidInput_ReturnsOkResult()
        {
            // Arrange
            var newTeacher = new TeacherDto
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateOnly(1990, 1, 15),
                Address = "123 Main St, Cityville",
                PhoneNumber = "+1 555-1234",
                Email = "john.doe@example.com"
            };

            // Mock the Send method of IMediator to return the expected result
            Mock.Get(_mediator)
                .Setup(x => x.Send(It.IsAny<AddTeacherCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Domain.Models.Teacher.Teacher());

            // Act
            var result = await _controller.AddTeacher(newTeacher);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            Assert.That((result as OkObjectResult)?.StatusCode, Is.EqualTo(200));
        }
    }
}
