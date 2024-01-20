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
        private Mock<IMediator> _mediatorMock;

        [SetUp]
        public void Setup()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new StudentController(_mediatorMock.Object);
        }

        [Test]
        public async Task AddStudent_ValidInput_ReturnsOkResult()
        {
            // Arrange
            var studentDto = new StudentDto
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1990, 1, 15),
                Address = "123 Main St, Cityville",
                PhoneNumber = "+1 555-1234",
                Email = "john.doe@example.com"
            };

            var expectedResult = new Student // Replace with your expected result
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1990, 1, 15),
                Address = "123 Main St, Cityville",
                PhoneNumber = "+1 555-1234",
                Email = "john.doe@example.com"
            };

            _mediatorMock.Setup(mediator => mediator.Send(It.IsAny<AddStudentCommand>(), default)).ReturnsAsync(expectedResult);

            // Act
            var result = await _controller.AddStudent(studentDto) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);

            // Optionally, assert on the content of the result
            var addedStudent = result.Value as Student;
            Assert.IsNotNull(addedStudent);
            Assert.AreEqual(expectedResult.Id, addedStudent.Id);
            // Continue asserting on other properties

            // Verify that Send method was called with the correct command
            _mediatorMock.Verify(mediator => mediator.Send(It.IsAny<AddStudentCommand>(), default), Times.Once);
        }

        
    }
}
