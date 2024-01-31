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
			_userRepository.Setup(repo => repo.AuthenticationUserLogin(It.IsAny<string>()))
				.ReturnsAsync((string loginUser) =>
				{
					return users.Find(u => u.Username == loginUser);
				});
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
		public void Handle_InValidCommand_EmptyUserName()
		{
			// Arrange
			var users = new List<User>();
			SetupMockUserRepository(users);
			var command = new LoginUserQuery(
				new UserDto
				{
					Username = "",
					Password = "NemasProblemas"
				});

			// Act & Assert
			var exception = Assert.ThrowsAsync<ArgumentException>(() => _handler.Handle(command, CancellationToken.None));
			Assert.That(exception.Message, Is.EqualTo("Username or password cannot be empty."));
		}

		[Test]
		public void Handle_InValidCommand_IncorrectPassword()
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
				Password = "WrongPassword"
			});

			// Act & Assert
			var exception = Assert.ThrowsAsync<ArgumentException>(() => _handler.Handle(command, CancellationToken.None));
			Assert.That(exception.Message, Is.EqualTo("Invalid username or password."));
		}
	}
}