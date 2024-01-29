using Domain.Models.Users;
using Infrastructure.Repositories.Users;
using MediatR;

namespace Application.Queries.Users.Login
{
	public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, User>
    {
		private readonly IUserRepository _userRepository;
		public LoginUserQueryHandler(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
			if (string.IsNullOrWhiteSpace(request.Username))
			{
				throw new ArgumentException("Username cannot be null or empty.", nameof(request.Username));
			}

			var user = await _userRepository.LoginUser(request.Username);
			if (user == null)
			{
				// Hantera fallet där användaren inte hittas. Du kan kasta ett undantag eller returnera null.
				throw new KeyNotFoundException($"Användare med användarnamnet '{request.Username}' hittades inte.");
			}

			return user;
		}
    }
}
