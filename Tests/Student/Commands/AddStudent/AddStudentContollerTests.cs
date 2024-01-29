using System;
using System.Threading.Tasks;
using Application.Commands.Students.AddStudent;
using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ReactApp.Server.Controllers.StudentController;

namespace Tests.Student.Controllers
{
    [TestFixture]
    public class AddStudentControllerTests
    {
        private StudentController _controller;
        private IMediator _mediator;

        [SetUp]
        public void Setup()
        {
            // Initialize or mock IMediator implementation (dependency injection)
            _mediator = Mock.Of<IMediator>();

            _controller = new StudentController(_mediator);
        }

        [Test]
        public async Task AddStudent_ValidInput_ReturnsOkResult()
        {
            // Arrange
            var newStudent = new StudentDto
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
                .Setup(x => x.Send(It.IsAny<AddStudentCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Domain.Models.Student.Student());

            // Act
            var result = await _controller.AddStudent(newStudent);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            Assert.That((result as OkObjectResult)?.StatusCode, Is.EqualTo(200));
        }
    }
}
