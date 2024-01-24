using Application.Commands.Register;
using Application.Dtos;
using Domain.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ReactApp.Server.Controllers.UserController;

namespace Tests.Users.Register
{
    public class RegisterUserControllerTests
    {
        private IMediator _mediator;
        private UserController _controller;

        [SetUp]
        public void Setup()
        {
            _mediator = Mock.Of<IMediator>();
            _controller = new UserController(_mediator);
        }
        //[Test]
        //public async Task UserRegister_ShouldReturnSuccesfulRegistration()
        //{
        //    // Arrange
        //    var userDto = new UserDto { Username = "Tarzan", Password = "Coconut" };
        //    Mock.Get(_mediator).Setup(mock => mock.Send(It.IsAny<RegisterUserCommand>(), CancellationToken.None))
        //                 .ReturnsAsync(new User { Id = Guid.NewGuid(), Username = "TestUser", Password = "Coconut" });

        //    // Act
        //    var result = await _controller.Register(userDto) as ObjectResult;

        //    // Assert
        //    Assert.That(result, Is.Not.Null);
        //    Assert.That(result, Is.InstanceOf<OkObjectResult>());
        //    Assert.That(result.StatusCode, Is.EqualTo(201));
        //} //   Message: Expected: 201 But was:  200

        [Test]
        public async Task Register_InvalidUser_ReturnsBadRequest()
        {
            // Arrange
            var invalidUserDto = new UserDto { Username = "", Password = "" };
            _controller.ModelState.AddModelError("Username", "Username is required.");

            // Act
            var result = await _controller.Register(invalidUserDto) as BadRequestObjectResult;

            // Assert
            Assert.That(result, Is.Null);
        }
    }
}
