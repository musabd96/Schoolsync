using Application.Dtos;
using Application.Queries.Students.GetAllStudents;
using Domain.Models.Student;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ReactApp.Server.Controllers.StudentController;

namespace Tests.Student.Queries.GetAll
{
    [TestFixture]
    public class GetAllStudentControllerTests
    {
        private IMediator _mediator;
        private StudentController _controller;

        [SetUp]
        public void Setup()
        {
            // Initialize or mock IMediator implementation (dependency injection)
            _mediator = Mock.Of<IMediator>();

            _controller = new StudentController(_mediator);
        }

        [Test]
        public async Task GetAllStudents_ShouldReturnOk()
        {
            // Arrange
            var expectedStudents = new List<StudentModel>
        {
            new StudentModel
            {
                FirstName = "Per",
                LastName = "Andersson",
                DateOfBirth = new DateOnly(2003, 5, 12),
                Adress = "Kungsgatan 123, Göteborg",
                PhoneNumber = "+46 70 123 45 67",
                Email = "elsa.andersson@schoolsync.com"
            },
            new StudentModel           {
                FirstName = "Nelson",
                LastName = "Doe",
                DateOfBirth = new DateOnly(2005, 5, 5),
                Adress = "Magasinsgatan 1414, Mölndal",
                PhoneNumber = "+46 76 789 01 23",
                Email = "nelson.doe@schoolsync.com"
            }
        };

            var query = new GetAllStudentsQuery();

            // Mock the Send method of IMediator to return the expected result
            // Mock the Send method of IMediator to return the expected result
            Mock.Get(_mediator)
                .Setup(x => x.Send(It.IsAny<GetAllStudentsQuery>(), default(CancellationToken)))
                .ReturnsAsync(expectedStudents);


            // Act
            var result = await _controller.GetAllStudents();

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            Assert.That((result as OkObjectResult)?.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public async Task GetAllStudents_ShouldReturnInternalServerErrorOnException()
        {
            // Arrange
            Mock.Get(_mediator)
                .Setup(x => x.Send(It.IsAny<GetAllStudentsQuery>(), default))
                .Throws(new Exception("Simulated error"));

            // Act
            var result = await _controller.GetAllStudents();

            // Assert
            Assert.That(result, Is.InstanceOf<ObjectResult>());
            Assert.That((result as ObjectResult)?.StatusCode, Is.EqualTo(500));
        }

    }
}
