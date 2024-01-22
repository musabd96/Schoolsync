using Application.Queries.Teachers.GetAllTeachers;
using Domain.Models.Teacher;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ReactApp.Server.Controllers.TeacherController;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Tests.Teacher.Queries.GetAll
{
    [TestFixture]
    public class GetAllTeacherControllerTests
    {
        private IMediator _mediator;
        private TeacherController _controller;

        [SetUp]
        public void Setup()
        {
            // Initialize or mock IMediator implementation (dependency injection)
            _mediator = Mock.Of<IMediator>();

            _controller = new TeacherController(_mediator);
        }

        [Test]
        public async Task GetAllTeachers_ShouldReturnOk()
        {
            // Arrange
            var expectedTeachers = new List<Domain.Models.Teacher.Teacher>
            {
                new Domain.Models.Teacher.Teacher
                {
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = new DateOnly(1982, 1, 15),
                    Address = "123 Main St, Cityville",
                    PhoneNumber = "+1 555-1234",
                    Email = "john.doe@example.com"
                },
                new Domain.Models.Teacher.Teacher
                {
                    FirstName = "Jane",
                    LastName = "Smith",
                    DateOfBirth = new DateOnly(1975, 6, 22),
                    Address = "456 Oak St, Townsville",
                    PhoneNumber = "+1 555-5678",
                    Email = "jane.smith@example.com"
                }
            };

            var query = new GetAllTeachersQuery();

            // Mock the Send method of IMediator to return the expected result
            Mock.Get(_mediator)
                .Setup(x => x.Send(It.IsAny<GetAllTeachersQuery>(), default(CancellationToken)))
                .ReturnsAsync(expectedTeachers);

            // Act
            var result = await _controller.GetAllTeachers();

            // Assert
            Assert.That(result, Is.InstanceOf<OkObjectResult>());
            Assert.That((result as OkObjectResult)?.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public async Task GetAllTeachers_ShouldReturnInternalServerErrorOnException()
        {
            // Arrange
            Mock.Get(_mediator)
                .Setup(x => x.Send(It.IsAny<GetAllTeachersQuery>(), default))
                .Throws(new Exception("Simulated error"));

            // Act
            var result = await _controller.GetAllTeachers();

            // Assert
            Assert.That(result, Is.InstanceOf<ObjectResult>());
            Assert.That((result as ObjectResult)?.StatusCode, Is.EqualTo(500));
        }
    }
}
