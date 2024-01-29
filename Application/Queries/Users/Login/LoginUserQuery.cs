using Application.Dtos;
using MediatR;

namespace Application.Queries.Users.Login
{
	public class LoginUserQuery : IRequest<string>
    {
		public UserDto LoginUser { get; set; }
		public LoginUserQuery(UserDto loginUser)
		{
			LoginUser = loginUser;
		}
	}
}
