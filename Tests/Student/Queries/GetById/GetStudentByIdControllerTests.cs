using Application.Queries.Students.GetStudentById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ReactApp.Server.Controllers.StudentController;

namespace Tests.Student.Queries.GetById
{
	[TestFixture]
	public class GetStudentByIdControllerTests
	{
		private IMediator _mediator;
		private StudentController _controller;

		[SetUp]
		public void Setup()
		{
			_mediator = Mock.Of<IMediator>();
			_controller = new StudentController(_mediator);
		}

		[Test]
		public async Task GetStudentById_ReturnsOkObjectResult_WhenStudentExists()
		{
			// Arrange
			var studentId = new Guid();
			var expectedStudent = new Domain.Models.Student.Student();

			Mock.Get(_mediator)
				.Setup(mediator => mediator.Send(It.IsAny<GetStudentByIdQuery>(), It.IsAny<CancellationToken>()))
				.ReturnsAsync(expectedStudent);

			// Act
			var result = await _controller.GetStudentById(studentId);

			// Assert
			Assert.That(result, Is.InstanceOf<OkObjectResult>());
			Assert.That((result as OkObjectResult)?.StatusCode, Is.EqualTo(200));
		}
		[Test]
		public async Task GetStudentById_ShouldReturnInternalServerErrorOnException()
		{
			// Arrange
			var studentId = new Guid();

			Mock.Get(_mediator)
				.Setup(mediator => mediator.Send(It.IsAny<GetStudentByIdQuery>(), It.IsAny<CancellationToken>()))
				.ThrowsAsync(new Exception("Simulated exception"));

			// Act
			var result = await _controller.GetStudentById(studentId);

			// Assert
			Assert.That(result, Is.InstanceOf<ObjectResult>());
			var objectResult = (ObjectResult)result;
			Assert.That(objectResult.StatusCode, Is.EqualTo(500));
		}

	}
}
