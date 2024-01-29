using Domain.Models.Users;
using MediatR;

namespace Application.Queries.Users.Login
{
	public class LoginUserQuery : IRequest<User>
    {
		public string Username { get; set; }
		public LoginUserQuery(string username)
		{
			Username = username;
		}
	}
}
