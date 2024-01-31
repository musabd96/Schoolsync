using Infrastructure.Repositories.Users;
using MediatR;

namespace Application.Queries.Users.Login
{
	public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, string>
	{
		private readonly IUserRepository _userRepository;
		public LoginUserQueryHandler(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public async Task<string> Handle(LoginUserQuery request, CancellationToken cancellationToken)
		{
			var user = await _userRepository.AuthenticationUserLogin(request.LoginUser.Username, request.LoginUser.Password);

			if (user == null)
			{
				// Hantera fallet där användaren inte hittas. Du kan kasta ett undantag eller returnera null.
				throw new UnauthorizedAccessException("username is not found");
			}


			return user.Username;
		}
	}
}
