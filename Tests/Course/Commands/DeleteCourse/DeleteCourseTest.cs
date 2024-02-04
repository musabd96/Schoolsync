using Application.Commands.Course.DeleteCourse;
using Domain.Models.Course;
using Infrastructure.Repositories.Course;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Tests.Course.Commands.DeleteCourse
{
    [TestFixture]
    public class DeleteCourseTest
    {
        private DeleteCourseCommandHandler _handler;
        private Mock<ICourseRepository> _courseRepository;

        [SetUp]
        public void SetUp()
        {
            _courseRepository = new Mock<ICourseRepository>();
            _handler = new DeleteCourseCommandHandler(_courseRepository.Object);
        }

        protected void SetupMockDbContext(List<Domain.Models.Course.Course> course)
        {
            _courseRepository.Setup(repo => repo.DeleteCourse(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .Returns((Guid courseId, CancellationToken cancellationToken) =>
                {
                    var courseToDelete = course.FirstOrDefault(c => c.Id == courseId);

                    return Task.FromResult<Domain.Models.Course.Course>(null!);
                });
        }

        [Test]
        public async Task DeleteCourseById_ReturnsOkObjectResult_WhenCourseExists()
        {
            // Arrange
            var courseId = new Guid("12345678-1234-5678-1234-567812345678");
            var course = new List<Domain.Models.Course.Course>
            {
                new Domain.Models.Course.Course
                {
                    Id = courseId
                }
            };
            SetupMockDbContext(course);

            var command = new DeleteCourseCommand(courseId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Null(result);
        }

        [Test]
        public async Task Handle_InvalidId_DoesNothing()
        {
            // Arrange
            var invalidCourseId = Guid.NewGuid();
            var course = new List<Domain.Models.Course.Course>();
            SetupMockDbContext(courserooms);

            var command = new DeleteCourseCommand(invalidCourseId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.IsNull(result);
        }
    }
}
