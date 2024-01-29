using Application.Queries.Teachers.GetAllTeachers;
using Infrastructure.Repositories.Teachers;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Tests.Teacher.Queries.GetAll
{
    [TestFixture]
    public class GetAllTeachersTests
    {
        private GetAllTeachersQueryHandler _handler;
        private GetAllTeachersQuery _request;
        private Mock<ITeacherRepository> _teacherRepositoryMock;

        [SetUp]
        public void Setup()
        {
            _teacherRepositoryMock = new Mock<ITeacherRepository>();
            _handler = new GetAllTeachersQueryHandler(_teacherRepositoryMock.Object);
            _request = new GetAllTeachersQuery();
        }

        protected void SetupMockDbContext(List<Domain.Models.Teacher.Teacher> teachers)
        {
            _teacherRepositoryMock.Setup(repo => repo.GetAllTeachers(It.IsAny<CancellationToken>()))
                .ReturnsAsync(teachers);
        }

        [Test]
        public async Task Handle_Valid_ReturnsAllTeachers()
        {
            // Arrange
            var teachersList = new List<Domain.Models.Teacher.Teacher>
            {
                new Domain.Models.Teacher.Teacher
                {
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = new DateOnly(1982, 1, 15),
                    Adress = "123 Main St, Cityville",
                    PhoneNumber = "+1 555-1234",
                    Email = "john.doe@example.com"
                },
                new Domain.Models.Teacher.Teacher
                {
                    FirstName = "Jane",
                    LastName = "Smith",
                    DateOfBirth = new DateOnly(1975, 6, 22),
                    Adress = "456 Oak St, Townsville",
                    PhoneNumber = "+1 555-5678",
                    Email = "jane.smith@example.com"
                }
            };

            SetupMockDbContext(teachersList);

            // Act
            var result = await _handler.Handle(_request, CancellationToken.None);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.EqualTo(teachersList.Count));
        }

        [Test]
        public async Task Handle_InvalidDatabase_ReturnsNullOrEmptyList()
        {
            // Arrange
            var emptyTeachersList = new List<Domain.Models.Teacher.Teacher>();
            SetupMockDbContext(emptyTeachersList);

            // Act
            var result = await _handler.Handle(_request, CancellationToken.None);

            // Assert
            Assert.IsEmpty(result);
        }
    }
}
