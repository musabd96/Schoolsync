using Application.Dtos;
using Application.Queries.Users.Login;
using Domain.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ReactApp.Server.Controllers.UserController;

namespace Tests.Users.Login
{
	public class LoginUserControllerTests
	{
		private IMediator _mediator;
		private UserController _controller;

		[SetUp]
		public void Setup()
		{
			_mediator = Mock.Of<IMediator>();
			_controller = new UserController(_mediator);
		}

		[Test]
		public async Task UserLogin_ShouldReturnSuccessfulLogin()
		{
			// Arrange
			var userDto = new UserDto { Username = "Alice", Password = "Wonderland" };
			Mock.Get(_mediator).Setup(mock => mock.Send(It.IsAny<LoginUserQuery>(), CancellationToken.None))
							 .ReturnsAsync(new User { Id = Guid.NewGuid(), Username = "TestUser", PasswordHash = "Wonderland" });

			// Act
			var result = await _controller.Login(userDto) as OkObjectResult;

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result.StatusCode, Is.EqualTo(200));
			// Add more specific assertions based on your login implementation
		}

		[Test]
		public async Task Login_InvalidUser_ReturnsBadRequest()
		{
			// Arrange
			var invalidUserDto = new UserDto { Username = "", Password = "" };
			_controller.ModelState.AddModelError("Username", "Username is required.");

			// Act
			var result = await _controller.Login(invalidUserDto) as BadRequestObjectResult;

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.That(result.StatusCode, Is.EqualTo(400));
			// Add more specific assertions based on your validation implementation
		}
	}
}
