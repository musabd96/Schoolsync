using Application.Commands.Students.UpdateStudent;
using Application.Validators.Students;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ReactApp.Server.Controllers.StudentController;

namespace Tests.Student.Commands.UpdateStudent
{
    [TestFixture]
    public class UpdateStudentControllerTests
    {
        private IMediator _mediator;
        private StudentValidator _studentValidator;
        private StudentController _controller;

        [SetUp]
        public void Setup()
        {
            _mediator = Mock.Of<IMediator>();
            _studentValidator = new StudentValidator();
            _controller = new StudentController(_mediator, _studentValidator);
        }

        [Test]
        public async Task UpdateStudent_ReturnsOkObjectResult_WhenUpdateSuccessful()
        {
            // Arrange
            var updateStudentId = Guid.NewGuid();
            var updatedStudentDto = new Application.Dtos.StudentDto
            {
                FirstName = "Test",
                LastName = "Testsson",
                DateOfBirth = new DateOnly(1990, 1, 15),
                Address = "123 Main St, Cityville",
                PhoneNumber = "07066665415",
                Email = "john.doe@example.com"
            };

            var command = new UpdateStudentCommand(updatedStudentDto, updateStudentId);
            Mock.Get(_mediator)
                .Setup(mediator => mediator.Send(It.IsAny<UpdateStudentCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Domain.Models.Student.Student());

            // Act
            var result = await _controller.UpdateStudent(updatedStudentDto, updateStudentId);

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            Assert.That((result as OkObjectResult)?.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public async Task UpdateStudent_ShouldReturnBadRéquest()
        {
            // Arrange
            var updateStudentId = Guid.NewGuid();
            var updatedStudentDto = new Application.Dtos.StudentDto(); // Provide valid DTO for testing

            Mock.Get(_mediator)
                .Setup(mediator => mediator.Send(It.IsAny<UpdateStudentCommand>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception("Simulated exception"));

            // Act
            var result = await _controller.UpdateStudent(updatedStudentDto, updateStudentId);

            // Assert
            Assert.That(result, Is.InstanceOf<ObjectResult>());
            var objectResult = (ObjectResult)result;
            Assert.That(objectResult.StatusCode, Is.EqualTo(400));
        }
    }
}
