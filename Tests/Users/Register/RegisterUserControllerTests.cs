using Application.Commands.Register;
using Application.Dtos;
using Domain.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using ReactApp.Server.Controllers.UserController;

namespace Tests.Users.Register
{
    public class RegisterUserControllerTests
    {
        private IMediator _mediator;
        private UserController _controller;
        private Mock<IConfiguration> _configuration;

        [SetUp]
        public void Setup()
        {
            _mediator = Mock.Of<IMediator>();
            _configuration = new Mock<IConfiguration>();
            _controller = new UserController(_mediator, _configuration.Object);
        }

        [Test]
        public async Task UserRegister_ShouldReturnSuccessfulRegistration()
        {
            // Arrange
            var userDto = new UserDto { Username = "Tarzan", Password = "Coconut" };
            Mock.Get(_mediator).Setup(mock => mock.Send(It.IsAny<RegisterUserCommand>(), CancellationToken.None))
                               .ReturnsAsync(new User { Id = Guid.NewGuid(), Username = "TestUser", PasswordHash = "Coconut" });

            // Act
            var result = await _controller.Register(userDto) as CreatedAtActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(201, result.StatusCode);
            Assert.AreEqual("userToRegister", result.ActionName); // Make sure this matches the action name in your controller
        }


        [Test]
        public async Task Register_InvalidUser_ReturnsBadRequest()
        {
            // Arrange
            var invalidUserDto = new UserDto { Username = "", Password = "" };

            // Simulate model state error
            _controller.ModelState.AddModelError("Username", "Username is required.");
            _controller.ModelState.AddModelError("Password", "Password is required.");

            // Act
            var result = await _controller.Register(invalidUserDto) as BadRequestObjectResult;

            // Assert
            Assert.IsNotNull(result); // Ensure that a BadRequestObjectResult is returned
            Assert.AreEqual(400, result.StatusCode);
        }

    }
}
