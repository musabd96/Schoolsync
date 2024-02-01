using Application.Commands.Students.AddStudent;
using Application.Dtos;
using Application.Validators.Students;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ReactApp.Server.Controllers.StudentController;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Tests.Student.Controllers
{
    [TestFixture]
    public class AddStudentControllerTests
    {
        private StudentController _controller;
        private IMediator _mediator;
        private StudentValidator _studentValidator;

        [SetUp]
        public void Setup()
        {
            // Initialize or mock IMediator implementation (dependency injection)
            _mediator = Mock.Of<IMediator>();
            _studentValidator = Mock.Of<StudentValidator>();
            _controller = new StudentController(_mediator, _studentValidator);
        }

        [Test]
        public async Task AddStudent_ValidInput_ReturnsOkResult()
        {
            // Arrange
            var validationErrors = new List<ValidationFailure>();
            var newStudent = new StudentDto
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateOnly(1990, 1, 15),
                Address = "123 Main St, Cityville",
                PhoneNumber = "07066665415",
                Email = "john.doe@example.com"
            };

            var validationResult = new ValidationResult(validationErrors);

            Mock.Get(_studentValidator)
                .Setup(v => v.ValidateAsync(It.IsAny<ValidationContext<StudentDto>>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(validationResult);

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
