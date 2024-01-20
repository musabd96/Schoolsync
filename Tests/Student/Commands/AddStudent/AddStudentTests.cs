using Application.Commands.Students.AddStudent;
using Domain.Models.Student;
using Infrastructure.Repositories.Students;
using Moq;
using NUnit.Framework;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tests.Student.Commands.AddStudent
{
    [TestFixture]
    public class AddStudentTests
    {
        private AddStudentCommandHandler? _handler;
        private Mock<IStudentRepository>? _studentRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _studentRepositoryMock = new Mock<IStudentRepository>();
            _handler = new AddStudentCommandHandler(_studentRepositoryMock.Object);
        }

        [Test]
        public async Task Handle_ValidStudent_ReturnsNewStudent()
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

            var addStudentCommand = new AddStudentCommand(studentDto);

            // Act
            var result = await _handler!.Handle(addStudentCommand, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result, "The result should not be null");
            Assert.AreEqual(studentDto.FirstName, result.FirstName);
            Assert.AreEqual(studentDto.LastName, result.LastName);
            Assert.AreEqual(studentDto.DateOfBirth, result.DateOfBirth);
            Assert.AreEqual(studentDto.Address, result.Address);
            Assert.AreEqual(studentDto.PhoneNumber, result.PhoneNumber);
            Assert.AreEqual(studentDto.Email, result.Email);

            // Verify that AddStudent method was called with the correct parameters
            _studentRepositoryMock.Verify(repo => repo.AddStudent(It.IsAny<Student>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
