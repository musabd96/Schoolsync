using Application.Commands.Students.DeleteStudent;
using Domain.Models.Student;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ReactApp.Server.Controllers.StudentController;


namespace Tests.Student.Commands.Delete_Student
{
    [TestFixture]
    public class DeleteStudentControllerTest
    {

        private Mock<IMediator> _mockMediator;
        private StudentController _studentController;

        [SetUp]

        public void Setup()
        {
            _mockMediator = new Mock<IMediator>();

            _studentController = new StudentController(_mockMediator.Object);
        }

        [Test]
        public async Task DeleteStudent_WithValisId_ShouldreturnNoContent()
        {
            //Arrange
            var ValidId = Guid.NewGuid();
            _mockMediator.Setup(m => m.Send(It.IsAny<DeleteStudentCommand>(), It.IsAny<CancellationToken>()))
                            .ReturnsAsync(new Domain.Models.Student.Student());

            //Act

            var result = await _studentController.DeleteStudent(ValidId);



            //Assert
            Assert.IsInstanceOf<NoContentResult>(result);

        }


        [Test]
        public async Task DeleteStudent_WithInvalidId_ShouldReturnNotFound()
        {
            // Arrange
            var invalidId = Guid.NewGuid();
            _mockMediator.Setup(m => m.Send(It.IsAny<DeleteStudentCommand>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync((Domain.Models.Student.Student)null);
            //Act
            var result = await _studentController.DeleteStudent(invalidId);

            //Assert
            Assert.IsInstanceOf<NotFoundResult>(result);


        }









    }
}
