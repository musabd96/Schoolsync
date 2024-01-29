using Application.Commands.Students.UpdateStudent;
using MediatR;
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
        private StudentController _controller;

        [SetUp]
        public void Setup()
        {
            _mediator = Mock.Of<IMediator>();
            _controller = new StudentController(_mediator);
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
        public async Task UpdateStudent_ShouldReturnInternalServerErrorOnException()
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
            Assert.That(objectResult.StatusCode, Is.EqualTo(500));
        }
    }
}
