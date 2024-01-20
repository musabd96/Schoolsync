using Application.Commands.Teachers.DeleteTeacher;
using Domain.Models.Teacher;
using Infrastructure.Repositories.Teachers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Teacher.Commands.DeleteTeacher
{
    [TestFixture]
    public class DeleteTeacherTest
    {
        private DeleteTeacherCommandHandler _handler;
        private Mock<ITeacherRepository> _teacherRepository;

        [SetUp]
        public void SetUp()
        {
            _teacherRepository = new Mock<ITeacherRepository>();
            _handler = new DeleteTeacherCommandHandler(_teacherRepository.Object);
        }

        protected void SetupMockDbContext(List<Domain.Models.Teacher.Teacher> teacher)
        {
            _teacherRepository.Setup(repo => repo.DeleteTeacher(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .Returns((Guid catId, CancellationToken cancellationToken) =>
                {
                    var birdToDelete = teacher.FirstOrDefault(bird => bird.Id == catId);

                    return Task.FromResult<Domain.Models.Teacher.Teacher>(null!);
                });
        }

        [Test]
        public async Task DeleteTeacherById_ReturnsOkObjectResult_WhenTeacherExists()
        {
            // Arrange
            var teacherId = new Guid("12345678-1234-5678-1234-567812345678");
            var teacher = new List<Domain.Models.Teacher.Teacher>
            {
                new Domain.Models.Teacher.Teacher
                {
                    Id = teacherId
                }
            };
            SetupMockDbContext(teacher);

            var command = new DeleteTeacherCommand(teacherId);

            //Act
            var result = await _handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.Null(result);
        }

        [Test]
        public async Task Handle_InvalidId_DoesNothing()
        {
            // Arrange
            var invalidTeacherId = Guid.NewGuid();
            var teacher = new List<Domain.Models.Teacher.Teacher>();
            SetupMockDbContext(teacher);

            var command = new DeleteTeacherCommand(invalidTeacherId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }
}
