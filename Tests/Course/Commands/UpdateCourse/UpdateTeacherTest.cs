using Application.Commands.Courses.UpdateCourse;
using Application.Dtos;
using Infrastructure.Repositories.Courses;
using Moq;
using NUnit.Framework;

namespace Tests.Course.Commands.UpdateCourse
{
    [TestFixture]
    public class UpdateCourseTest
    {
        private UpdateCourseCommandHandler _handler;
        private Mock<ICourseRepository> _courseRepository;

        [SetUp]
        public void SetUp()
        {
            _courseRepository = new Mock<ICourseRepository>();
            _handler = new UpdateCourseCommandHandler(_courseRepository.Object);
        }

        protected void SetupMockDbContext(List<Domain.Models.Course.Course> courses)
        {
            _courseRepository.Setup(repo => repo.UpdateCourse(
                It.IsAny<Guid>(),
                It.IsAny<string>(),
                It.IsAny<CancellationToken>()
            ))
            .ReturnsAsync(
                (Guid id, string courseName, CancellationToken cancellationToken) =>
                {
                    var courseToUpdate = courses.FirstOrDefault(c => c.Id == id);
                    return courseToUpdate!;
                }
             );
        }

        [Test]
        public async Task Handle_ValidId_UpdatedCourse()
        {
            // Arrange
            var courseId = new Guid("12345678-1234-5678-1234-567812345678");
            var courses = new List<Domain.Models.Course.Course> { new() { Id = courseId } };
            SetupMockDbContext(courses);

            var command = new UpdateCourseCommand(
                updatedCourse: new CourseDto
                {
                    CourseName = "Svenska 1",
                },
                id: courseId
            );

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(courseId));
        }

        [Test]
        public async Task Handle_InvalidId_ReturnsNull()
        {
            // Arrange
            var invalidCourseId = Guid.NewGuid();
            var courses = new List<Domain.Models.Course.Course>();
            SetupMockDbContext(courses);

            var command = new UpdateCourseCommand(updatedCourse: new CourseDto(), id: invalidCourseId);

            // ACt
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Null);
        }
    }
}
