using Application.Commands.Register;
using Application.Dtos;
using Domain.Models.Users;
using Infrastructure.Repositories.Users;
using Moq;
using NUnit.Framework;

namespace Tests.Users.Register
{
    [TestFixture]
    public class RegisterUserTests
    {
        private RegisterUserCommandHandler _handler;
        private Mock<IUserRepository> _userRepository;

        [SetUp]
        public void Setup()
        {
            _userRepository = new Mock<IUserRepository>();
            _handler = new RegisterUserCommandHandler(_userRepository.Object);
        }

        protected void SetupMockUserRepository(List<User> users)
        {
            _userRepository.Setup(repo => repo.RegisterUser(It.IsAny<User>()))
            .ReturnsAsync((User newUser) =>
            {
                users.Add(newUser);
                return newUser;
            });
        }
        [Test]
        public async Task Handle_ValidCommand_CreatedUser()
        {
            // Arrange
            var users = new List<User>();
            SetupMockUserRepository(users);

            var command = new RegisterUserCommand(new UserDto
            {
                Username = "Bojan",
                Password = "GreatPassw0rd!"
            });

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result.Username, Is.EqualTo("Bojan"));
                Assert.That(BCrypt.Net.BCrypt.Verify("GreatPassw0rd!", result.Password), Is.True);
            });
        }

        [Test]
        public void Handle_InValidCommand_EmptyUserName()
        {
            // Arrange
            var users = new List<User>();
            SetupMockUserRepository(users);
            var command = new RegisterUserCommand(
                new UserDto
                {
                    Username = "",
                    Password = "NemasProblemas"
                });

            // Act & Assert
            var exception = Assert.ThrowsAsync<ArgumentException>(() => _handler.Handle(command, CancellationToken.None));
            Assert.That(exception.Message, Is.EqualTo("Username or password cannot be empty."));
        }
    }
}
