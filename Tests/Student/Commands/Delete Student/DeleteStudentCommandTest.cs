using Application.Commands.Students.DeleteStudent;
using Domain.Models.Student;
using Infrastructure.Repositories.Students;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tests.Student.Commands.Delete_Student
{
    [TestFixture]
    public class DeleteStudentCommandTest
    {
        private DeleteStudentCommandHandler _handler;
        private Mock<IStudentRepository> _studentRepository;

        [SetUp]
        public void Setup()
        {
            _studentRepository = new Mock<IStudentRepository>();
            _handler = new DeleteStudentCommandHandler(_studentRepository.Object);
        }

        [Test]
        public async Task DeleteStudent_WithValidId_ShouldReturnDeletedStudent()
        {
            // Arrange
            var validId = Guid.NewGuid();
            var student = new Domain.Models.Student.Student { Id = validId }; // Assuming Student has an Id property
            _studentRepository.Setup(repo => repo.GetStudentById(validId, It.IsAny<CancellationToken>())).ReturnsAsync(student);

            // Act
            var command = new DeleteStudentCommand(validId);
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result.Id, Is.EqualTo(validId));
            _studentRepository.Verify(repo => repo.DeleteStudent(validId, CancellationToken.None), Times.Once);
        }

        [Test]
        public void DeleteStudent_WithInvalidId_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var invalidId = Guid.NewGuid();
            _studentRepository.Setup(repo => repo.GetStudentById(invalidId, It.IsAny<CancellationToken>())).ReturnsAsync((Domain.Models.Student.Student)null);

            // Act
            var command = new DeleteStudentCommand(invalidId);

            // Assert
            var ex = Assert.ThrowsAsync<InvalidOperationException>(() => _handler.Handle(command, CancellationToken.None));
            Assert.That(ex.Message, Is.EqualTo("Error occurred while deleting the student."));
        }

    }
}
