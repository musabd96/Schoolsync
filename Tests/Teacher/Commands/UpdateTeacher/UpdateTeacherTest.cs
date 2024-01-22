using Application.Commands.Teachers.UpdateTeacher;
using Application.Dtos;
using Infrastructure.Repositories.Teachers;
using Moq;
using NUnit.Framework;

namespace Tests.Teacher.Commands.UpdateTeacher
{
    [TestFixture]
    public class UpdateTeacherTest
    {
        private UpdateTeacherCommandHandler _handler;
        private Mock<ITeacherRepository> _teacherRepository;

        [SetUp]
        public void SetUp()
        {
            _teacherRepository = new Mock<ITeacherRepository>();
            _handler = new UpdateTeacherCommandHandler(_teacherRepository.Object);
        }

        protected void SetupMockDbContext(List<Domain.Models.Teacher.Teacher> teachers)
        {
            _teacherRepository.Setup(repo => repo.UpdateTeacher(
                It.IsAny<Guid>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<DateOnly>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()
            ))
            .ReturnsAsync(
                (Guid id, string firstName, string lastName, DateOnly dateOfBirth, string address, string phoneNumber, string email, CancellationToken cancellationToken) =>
                {
                    var teacherToUpdate = teachers.FirstOrDefault(t => t.Id == id);
                    return teacherToUpdate!;
                }
             );
        }

        [Test]
        public async Task Handle_ValidId_UpdatedTeacher()
        {
            // Arrange
            var teacherId = new Guid("12345678-1234-5678-1234-567812345678");
            var teachers = new List<Domain.Models.Teacher.Teacher>
        {
            new Domain.Models.Teacher.Teacher
            {
                Id = teacherId
            }
        };
            SetupMockDbContext(teachers);

            var command = new UpdateTeacherCommand(
                updatedTeacher: new TeacherDto
                {
                    FirstName = "Yoda",
                    LastName = "Master",
                    Address = "Dagobah Swamp, Dagobah System",
                    PhoneNumber = "555-YODA",
                    Email = "yoda.master@jediorder.com"
                },
                id: teacherId
            );

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Id, Is.EqualTo(teacherId));
        }

        [Test]
        public async Task Handle_InvalidId_ReturnsNull()
        {
            // Arrange
            var invalidTeacherId = Guid.NewGuid();
            var teachers = new List<Domain.Models.Teacher.Teacher>();
            SetupMockDbContext(teachers);

            var command = new UpdateTeacherCommand(
                updatedTeacher: new TeacherDto
                {
                    // Set other properties as needed
                },
                id: invalidTeacherId
            );

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }
}
