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
        private Mock<IMediator> _mediatorMock;
        private UserController _controller;
        private Mock<IConfiguration> _configurationMock;

        [SetUp]
        public void Setup()
        {
            _mediatorMock = new Mock<IMediator>();
            _configurationMock = new Mock<IConfiguration>();
            _controller = new UserController(_mediatorMock.Object, _configurationMock.Object);
        }


        [Test]
        public async Task UserRegister_ShouldReturnSuccessfulRegistration()
        {
            // Arrange
            var userDto = new UserDto { Username = "Tarzan", Password = "Coconut" };
            var createdUser = new User { Id = Guid.NewGuid(), Username = userDto.Username, PasswordHash = "Coconut" };

            _mediatorMock.Setup(m => m.Send(It.IsAny<RegisterUserCommand>(), CancellationToken.None))
            .ReturnsAsync(createdUser);


            // Act
            var result = await _controller.Register(userDto) as CreatedAtActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(201));
            Assert.That(result.ActionName, Is.EqualTo(nameof(_controller.Register)));

            Assert.IsNotNull(result.Value);
            Assert.That(result.Value, Is.EqualTo(createdUser));
        }


        [Test]
        public async Task Register_InvalidUser_ReturnsBadRequest()
        {
            // Arrange
            var invalidUserDto = new UserDto { Username = "", Password = "" };

            // Instantiate the controller
            var controller = new UserController(_mediatorMock.Object, _configurationMock.Object);

            // Simulate model state error
            controller.ModelState.AddModelError("Username", "Username is required.");
            controller.ModelState.AddModelError("Password", "Password is required.");

            // Act
            var result = await controller.Register(invalidUserDto);

            // Assert
            Assert.IsNotNull(result, "Result should not be null.");

            var badRequestResult = result as BadRequestObjectResult;
            Assert.IsNotNull(badRequestResult, "Result should be of type BadRequestObjectResult.");
            Assert.That(badRequestResult.StatusCode, Is.EqualTo(400), "Status code should be 400.");

            var errors = badRequestResult.Value as SerializableError;
            Assert.IsNotNull(errors, "Result should contain errors.");
            Assert.IsTrue(errors.ContainsKey("Username"), "Errors should contain 'Username'.");
            Assert.IsTrue(errors.ContainsKey("Password"), "Errors should contain 'Password'.");
        }



    }
}
