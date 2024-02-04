using Application.Queries.Course.GetCoursesById;
using Infrastructure.Repositories.Course;
using Moq;
using NUnit.Framework;

namespace Tests.Course.Queries.GetById
{
    [TestFixture]
    public class GetCourseByIdTest
    {
        private GetCourseByIdQueryHandler? _handler;
        private Mock<ICourseRepository>? _courseRepositoryMock;

        public void Setup()
        {
            _courseRepositoryMock = new Mock<ICourseRepository>();
            _handler = new GetCourseByIdQueryHandler(_courseRepositoryMock.Object);

            _courseRepositoryMock.Setup(repo => repo.GetCourseById(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Domain.Models.Course.Course
                {
                    Id = new Guid("376ba7ab-47ee-4260-90c6-49c469e078f0"),
                    CourseName = "Matematik 1"
                });
        }
        [Test]
        public async Task Handle_ValidId_ReturnsCorrectCourse()
        {
            // Arrange
            Setup();
            var courseId = new Guid("376ba7ab-47ee-4260-90c6-49c469e078f0");

            var query = new GetCourseByIdQuery(courseId);

            // Act
            var result = await _handler!.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null, "The result should not be null");
            Assert.That(result.Id, Is.EqualTo(courseId));
        }

        [Test]
        public async Task Handle_InvalidId_ReturnsNull()
        {
            // Arrange
            Setup();
            var invalidCourseId = Guid.NewGuid();

            _courseRepositoryMock!.Setup(repo => repo.GetCourseById(invalidCourseId, It.IsAny<CancellationToken>()))
                .ReturnsAsync((Domain.Models.Course.Course)null!);

            var query = new GetCourseByIdQuery(invalidCourseId);

            // Act
            var result = await _handler!.Handle(query, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Null);
        }
    }
}
