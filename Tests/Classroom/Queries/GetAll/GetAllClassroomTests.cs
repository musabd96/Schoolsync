using Application.Queries.Classrooms.GetAllClassrooms;
using Infrastructure.Repositories.Classrooms;
using Moq;
using NUnit.Framework;

namespace Tests.Classroom.Queries.GetAll
{
    public class GetAllClassroomTests
    {
        private GetAllClassroomQueryHandler _handler;
        private GetAllClassroomQuery _request;
        private Mock<IClassroomRepository> _classroomRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _classroomRepositoryMock = new Mock<IClassroomRepository>();
            _handler = new GetAllClassroomQueryHandler(_classroomRepositoryMock.Object);
            _request = new GetAllClassroomQuery();
        }

        protected void SetupMockDbContext(List<Domain.Models.Classrooms.Classroom> classrooms)
        {
            _classroomRepositoryMock.Setup(repo => repo.GetAllClassrooms(It.IsAny<CancellationToken>()))
                .ReturnsAsync(classrooms);
        }

        [Test]
        public async Task Handle_Valid_ReturnsAllClassrooms()
        {
            // Arrange
            var classroomsList = new List<Domain.Models.Classrooms.Classroom>
            {
                new () {
                    ClassroomName = "Skogen"
                },
                new() {
                    ClassroomName = "The Imposter Classroom"
                }
            };

            SetupMockDbContext(classroomsList);

            // Act
            var result = await _handler.Handle(_request, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Count.EqualTo(classroomsList.Count));
        }

        [Test]
        public async Task Handle_InvalidDatabase_ReturnsNullOrEmptyList()
        {
            // Arrange
            var emptyClassroomsList = new List<Domain.Models.Classrooms.Classroom>();
            SetupMockDbContext(emptyClassroomsList);

            // Act
            var result = await _handler.Handle(_request, CancellationToken.None);

            // Assert
            Assert.That(result, Is.Empty);
        }
    }
}
