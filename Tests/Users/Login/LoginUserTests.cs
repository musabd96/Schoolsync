using Application.Dtos;
using Application.Queries.Users.Login;
using Domain.Models.Users;
using Infrastructure.Repositories.Users;
using Moq;
using NUnit.Framework;

namespace Tests.Users.Login
{
    [TestFixture]
    public class LoginUserTests
    {
        private LoginUserQueryHandler _handler;
        private Mock<IUserRepository> _userRepository;

        [SetUp]
        public void Setup()
        {
            _userRepository = new Mock<IUserRepository>();
            _handler = new LoginUserQueryHandler(_userRepository.Object);
        }

        protected void SetupMockUserRepository(List<User> users)
        {
            _userRepository.Setup(repo => repo.AuthenticationUserLogin(It.IsAny<string>(), It.IsAny<string>()))
                .Returns((string userName, string password) =>
                {
                    return Task.FromResult(users.Find(u => u.Username == userName && BCrypt.Net.BCrypt.Verify(password, u.PasswordHash))!);
                }
                );
        }

        [Test]
        public async Task Handle_ValidCommand_SuccessfulLogin()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Username = "Alice", PasswordHash = BCrypt.Net.BCrypt.HashPassword("SecurePassword123!") }
            };
            SetupMockUserRepository(users);

            var command = new LoginUserQuery(new UserDto
            {
                Username = "Alice",
                Password = "SecurePassword123!"
            });

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Username, Is.EqualTo("Alice"));
            });
        }


        [Test]
        public async Task Handle_InValidCommand_IncorrectPassword()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Username = "Alice", PasswordHash = BCrypt.Net.BCrypt.HashPassword("SecurePassword123!") }
            };
            SetupMockUserRepository(users);

            var command = new LoginUserQuery(new UserDto
            {
                Username = "Alice",
                Password = "WrongPassword123!"
            });



            // Act & Assert
            Assert.ThrowsAsync<UnauthorizedAccessException>(async () => await _handler.Handle(command, new CancellationToken()));
        }
    }
}