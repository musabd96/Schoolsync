using Application.Dtos;
using MediatR;

namespace Application.Queries.Users.Login
{
    public class LoginUserQuery : IRequest<string>
    {
        public LoginUserQuery(UserDto loginUser)
        {
            LoginUser = loginUser;
        }
        public UserDto LoginUser { get; set;}
    }
}
