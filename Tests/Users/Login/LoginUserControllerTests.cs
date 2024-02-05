using Application.Dtos;
using Application.Queries.Users.Login;
using Domain.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using ReactApp.Server.Controllers.UserController;

namespace Tests.Users.Login
{
    public class LoginUserControllerTests
    {
        private IMediator _mediator;
        private UserController _controller;
        private Mock<IConfiguration> _configuration;

        [SetUp]
        public void Setup()
        {
            _mediator = Mock.Of<IMediator>();
            _configuration = new Mock<IConfiguration>();
            _configuration.Setup(c => c["AppSettings:SecretKey"]).Returns(new string('a', 32));
            _configuration.Setup(c => c["AppSettings:Issuer"]).Returns("TestIssuer");
            _configuration.Setup(c => c["AppSettings:Audience"]).Returns("TestAudience");

            _controller = new UserController(_mediator, _configuration.Object);
        }

        [Test]
        public async Task UserLogin_ShouldReturnSuccessfulLogin()
        {
            // Arrange
            var userDto = new UserDto { Username = "Alice", Password = "Wonderland" };
            Mock.Get(_mediator)
                .Setup(m => m.Send(It.IsAny<LoginUserQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new User { Username = userDto.Username });

            // Act
            var result = await _controller.Login(userDto) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result); // Checks if the result is not null
            Assert.That(result.StatusCode, Is.EqualTo(200)); // Checks if the status code is 200
            Assert.IsNotNull(result.Value); // Checks if the result value is not null
        }



        [Test]
        public async Task Login_UnauthorizedUser_ReturnsUnauthorized()
        {
            // Arrange
            var invalidUserDto = new UserDto { Username = "invalidUser", Password = "invalidPass" };

            Mock.Get(_mediator)
                .Setup(m => m.Send(It.IsAny<LoginUserQuery>(), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new UnauthorizedAccessException("Invalid credentials"));

            // Act
            var result = await _controller.Login(invalidUserDto) as UnauthorizedObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(401));
            Assert.That(result.Value, Is.EqualTo("Invalid credentials"));
        }
    }
}
